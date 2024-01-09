using Cysharp.Threading.Tasks;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class HardDropper
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;

		public HardDropper(TetrominoGrid grid, Container container)
		{
			_grid = grid;
			_container = container;
		}

		public async UniTaskVoid Drop()
		{
			bool canMove;
			do
			{
				_grid.ClearTetrominoTiles(_container.CurrentTetromino);
				canMove = _grid.TryMoveTetromino(_container.CurrentTetromino, Vector2Int.down);
				_grid.PlaceTetromino(_container.CurrentTetromino);

				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			} while (canMove);

			_grid.ClearRows();
			_container.Land();
		}
	}
}