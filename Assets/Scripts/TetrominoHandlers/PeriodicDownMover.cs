using Cysharp.Threading.Tasks;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class PeriodicDownMover
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly Mover _mover;

		private readonly float _defaultMoveDelay = 0.5f;
		private float _currentMoveDelay;
		private float _timeRemaining;

		public PeriodicDownMover(TetrominoGrid grid, Container container, Mover mover)
		{
			_grid = grid;
			_container = container;
			_mover = mover;

			_currentMoveDelay = _defaultMoveDelay;
			_timeRemaining = _currentMoveDelay;
		}

		public async UniTaskVoid Move()
		{
			while (true)
			{
				await UniTask.Yield();

				bool canMove = true;
				while (canMove)
				{
					await UniTask.Yield(PlayerLoopTiming.Update);
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

		public bool TryMoveDown()
		{
			_timeRemaining = _currentMoveDelay;
			return _mover.TryTranslateTetromino(Vector2Int.down);
		}

		public void ScaleMoveDelay(float scale)
		{
			float newMoveDelay = _defaultMoveDelay * scale;
			_timeRemaining = Mathf.Lerp(0, newMoveDelay, _timeRemaining / _currentMoveDelay);
			_currentMoveDelay = newMoveDelay;
		}

		public void Lock()
		{
			(int min, int max) = GetTetrominoRowBoundary();
			_grid.ClearRows(min, max);
			_container.Land();
		}

		private (int min, int max) GetTetrominoRowBoundary()
		{
			var cells = _container.CurrentTetromino.Data.Cells;

			int minPosition = int.MaxValue;
			int maxPosition = int.MinValue;

			foreach (var cell in cells)
			{
				minPosition = Mathf.Min(minPosition, cell.y);
				maxPosition = Mathf.Max(maxPosition, cell.y);
			}

			return (minPosition + _container.CurrentTetromino.Position.y,
				maxPosition + _container.CurrentTetromino.Position.y);
		}
	}
}
