using System;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class DownMover
	{
		public event Action TetrominoPlaced;

		private readonly TetrominoGrid _grid;
		private readonly Container _tetromino;

		public DownMover(TetrominoGrid grid, Container tetromino)
		{
			_grid = grid;
			_tetromino = tetromino;
		}

		// TODO: Moving down
	}
}
