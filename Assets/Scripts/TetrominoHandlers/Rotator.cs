using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class Rotator
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;

		public Rotator(TetrominoGrid grid, Container tetramino)
		{
			_grid = grid;
			_container = tetramino;
		}

		public void Rotate(float direction)
		{
			_grid.ClearTetrominoTiles(_container.CurrentTetromino);

			int previousRotation = _container.CurrentTetromino.Data.RotationIndex;
			_container.CurrentTetromino.Data.RotationIndex += direction > 0 ? 1 : -1;
			_container.CurrentTetromino.Rotate(direction);

			if (!TryWallKicks(_container.CurrentTetromino.Data.RotationIndex, direction))
			{
				_container.CurrentTetromino.Data.RotationIndex = previousRotation;
				Rotate(-direction);
			}

			_grid.PlaceTetromino(_container.CurrentTetromino);
		}

		private bool TryWallKicks(int rotationIndex, float direction)
		{
			int wallKickIndex = GetWallKickIndex(rotationIndex, direction);
			Vector2Int[,] wallKicks = _container.CurrentTetromino.Data.WallKicks;

			for (int i = 0; i < wallKicks.GetLength(1); i++)
			{
				Vector2Int translation = wallKicks[wallKickIndex, i];

				if (_grid.TryMoveTetromino(_container.CurrentTetromino, translation))
					return true;
			}

			return false;
		}

		private int GetWallKickIndex(int rotationIndex, float direction)
		{
			int wallKickIndex = rotationIndex * 2;

			if (direction < 0)
				wallKickIndex--;

			int wallKicksLength = _container.CurrentTetromino.Data.WallKicks.GetLength(0);
			return (wallKickIndex + wallKicksLength) % wallKicksLength;
		}
	}
}