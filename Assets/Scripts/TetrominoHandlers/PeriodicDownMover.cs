using Configs;
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
		private readonly TetrominoMovementConfig _config;

		private float _currentMoveDelay;
		private float _timeRemaining;

		private CancellationTokenSource _cancellationSource;

		public PeriodicDownMover(
			Mover mover,
			TetrominoGrid grid,
			Container container,
			TetrominoMovementConfig config)
		{
			_grid = grid;
			_container = container;
			_mover = mover;
			_config = config;

			_currentMoveDelay = _config.DefaultMoveDelay;
			_timeRemaining = _currentMoveDelay;
			Dispose();
		}

		public void Start()
		{
			_cancellationSource?.Dispose();
			_cancellationSource = new();
			Move().Forget();
		}

		public void Stop()
		{
			_cancellationSource.Cancel();
		}

		public void ScaleMoveDelay(float scale)
		{
			float newMoveDelay = _config.DefaultMoveDelay * scale;
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
			_grid.ClearFilledRows(_container.CurrentTetromino);
			_container.Land();
		}

		public void Dispose()
		{
			_cancellationSource?.Cancel();
			_cancellationSource?.Dispose();
		}

		private async UniTaskVoid Move()
		{
			while (!_cancellationSource.IsCancellationRequested)
			{
				await UniTask.Yield();

				_timeRemaining = _currentMoveDelay;
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
