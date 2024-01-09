using Cysharp.Threading.Tasks;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class DownMover
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;

		private readonly float _moveDelay = 0.35f;

		public DownMover(TetrominoGrid grid, Container container)
		{
			_grid = grid;
			_container = container;
		}

		public async UniTaskVoid Move()
		{
			float timeRemaining = _moveDelay;

			while (true)
			{
				await UniTask.Yield();

				bool isPlaced = false;
				while (!isPlaced)
				{
					await UniTask.Yield(PlayerLoopTiming.Update);
					timeRemaining -= Time.deltaTime;

					if (timeRemaining < 0)
					{
						timeRemaining += _moveDelay;

						_grid.ClearTetrominoTiles(_container.CurrentTetromino);

						isPlaced = _grid.TryMoveTetromino(_container.CurrentTetromino, Vector2Int.down);

						_grid.PlaceTetromino(_container.CurrentTetromino);

						if (!isPlaced)
						{
							_grid.ClearRows();
							_container.Land();
						}
					}
				}
			}
		}
	}
}
