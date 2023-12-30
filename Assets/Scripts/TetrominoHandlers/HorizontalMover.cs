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

			Vector2Int newPosition = _container.CurrentTetromino.Position;
			if (direction > 0)
				newPosition.x++;
			else
				newPosition.x--;

			if (_grid.IsValidTetrominoPosition(newPosition, _container.CurrentTetromino))
				_container.CurrentTetromino.Position = newPosition;

			_grid.PlaceTetromino(_container.CurrentTetromino);
		}
	}
}
