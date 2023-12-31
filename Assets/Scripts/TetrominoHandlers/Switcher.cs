using System;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class Switcher : IDisposable
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly DownMover _downMover;
		private readonly TetrominoFactory _factory;

		public Switcher(
			TetrominoGrid grid,
			Container container,
			DownMover downMover,
			TetrominoFactory factory)
		{
			_grid = grid;
			_container = container;
			_downMover = downMover;
			_factory = factory;

			_downMover.TetrominoPlaced += SwitchTetromino;
		}

		private void SwitchTetromino()
		{
			var tetromino = _factory.Produce();
			_container.SwitchTetromino(tetromino);
			_grid.SpawnTetromino(tetromino);
		}

		public void Dispose()
		{
			_downMover.TetrominoPlaced -= SwitchTetromino;
		}
	}
}
