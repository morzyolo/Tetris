using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class Mover
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;

		public Mover(TetrominoGrid grid, Container container)
		{
			_grid = grid;
			_container = container;
		}

		public bool TryTranslateTetromino(Vector2Int translation)
		{
			_grid.ClearTetrominoTiles(_container.CurrentTetromino);

			Vector2Int newPosition = _container.CurrentTetromino.Position;
			newPosition.x += translation.x;
			newPosition.y += translation.y;

			bool isValid = _grid.IsValidTetrominoPosition(_container.CurrentTetromino, newPosition);

			if (isValid)
				_container.CurrentTetromino.Position = newPosition;

			_grid.PlaceTetromino(_container.CurrentTetromino);

			return isValid;
		}
	}
}
