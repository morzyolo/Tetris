using System;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class Switcher : IDisposable
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly TetrominoFactory _factory;

		public Switcher(
			TetrominoGrid grid,
			Container container,
			TetrominoFactory factory)
		{
			_grid = grid;
			_container = container;
			_factory = factory;

			_container.OnLanding += SwitchTetromino;
		}

		private void SwitchTetromino()
		{
			var tetromino = _factory.Produce();
			_container.SwitchTetromino(tetromino);
			_grid.SpawnTetromino(tetromino);
		}

		public void Dispose()
		{
			_container.OnLanding -= SwitchTetromino;
		}
	}
}
