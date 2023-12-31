using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class HorizontalMover
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;

		public HorizontalMover(TetrominoGrid grid, Container tetramino)
		{
			_grid = grid;
			_container = tetramino;
		}

		public void Move(float direction)
		{
			_grid.ClearTetrominoTiles(_container.CurrentTetromino);
			Vector2Int translation = direction < 0 ? Vector2Int.left : Vector2Int.right;
			_grid.TryMoveTetromino(_container.CurrentTetromino, translation);
			_grid.PlaceTetromino(_container.CurrentTetromino);
		}
	}
}
