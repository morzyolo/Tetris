using System;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public sealed class Switcher : IDisposable
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

			_container.OnLanded += SwitchTetromino;
		}

		public void SpawnInitialTetromino(int seed)
		{
			_factory.ChangeSeed(seed);
			SpawnTetromino();
		}

		private void SwitchTetromino()
		{
			var tetromino = _factory.Produce();
			_container.SwitchTetromino(tetromino);
			SpawnTetromino();
		}

		private void SpawnTetromino()
		{
			_container.CurrentTetromino.Position = _grid.SpawnPosition;
			_grid.PlaceTetromino(_container.CurrentTetromino);
		}

		public void Dispose()
		{
			_container.OnLanded -= SwitchTetromino;
		}
	}
}
