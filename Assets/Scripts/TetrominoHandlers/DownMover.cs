using Cysharp.Threading.Tasks;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class DownMover
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly Mover _mover;

		private readonly float _moveDelay = 0.35f;

		public DownMover(TetrominoGrid grid, Container container, Mover mover)
		{
			_grid = grid;
			_container = container;
			_mover = mover;
		}

		public async UniTaskVoid Move()
		{
			float timeRemaining = _moveDelay;

			while (true)
			{
				await UniTask.Yield();

				bool canMove = true;
				while (canMove)
				{
					await UniTask.Yield(PlayerLoopTiming.Update);
					timeRemaining -= Time.deltaTime;

					if (timeRemaining < 0)
					{
						timeRemaining += _moveDelay;

						canMove = TryMoveDown();
					}
				}
			}
		}

		public bool TryMoveDown()
		{
			bool canMove = _mover.TryTranslateTetromino(Vector2Int.down);

			if (!canMove)
			{
				_grid.ClearRows();
				_container.Land();
			}

			return canMove;
		}
	}
}
