using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public sealed class PeriodicDownMover : IDisposable
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly Mover _mover;

		private readonly float _defaultMoveDelay = 0.5f;

		private float _currentMoveDelay;
		private float _timeRemaining;

		private CancellationTokenSource _cancellationSource;

		public PeriodicDownMover(TetrominoGrid grid, Container container, Mover mover)
		{
			_grid = grid;
			_container = container;
			_mover = mover;

			_currentMoveDelay = _defaultMoveDelay;
			_timeRemaining = _currentMoveDelay;
			Dispose();
		}

		public void Start()
		{
			_cancellationSource?.Dispose();
			_cancellationSource = new();
			_ = Move();
		}

		public void Stop()
		{
			_cancellationSource.Cancel();
		}

		public void ScaleMoveDelay(float scale)
		{
			float newMoveDelay = _defaultMoveDelay * scale;
			_timeRemaining = Mathf.Lerp(0, newMoveDelay, _timeRemaining / _currentMoveDelay);
			_currentMoveDelay = newMoveDelay;
		}

		public bool TryMoveDown()
		{
			_timeRemaining = _currentMoveDelay;
			return _mover.TryTranslateTetromino(Vector2Int.down);
		}

		public void Lock()
		{
			_grid.ClearRows(_container.CurrentTetromino);
			_container.Land();
		}

		public void Dispose()
		{
			_cancellationSource?.Cancel();
			_cancellationSource?.Dispose();
		}

		private async UniTaskVoid Move()
		{
			_timeRemaining = _currentMoveDelay;

			while (!_cancellationSource.IsCancellationRequested)
			{
				await UniTask.Yield();

				bool canMove = true;
				while (canMove)
				{
					await UniTask.Yield(PlayerLoopTiming.Update, _cancellationSource.Token);
					if (_cancellationSource.IsCancellationRequested)
						return;

					_timeRemaining -= Time.deltaTime;

					if (_timeRemaining < 0)
					{
						canMove = TryMoveDown();

						if (!canMove && _container.TimeToLock > 0)
						{
							_timeRemaining += _container.TimeToLock;
							_container.TimeToLock = 0;
							canMove = true;
						}
					}
				}

				Lock();
			}
		}
	}
}
