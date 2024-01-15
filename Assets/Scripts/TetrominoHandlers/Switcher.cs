using System;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public sealed class Switcher : IDisposable
	{
		public event Action OntSwitchFailed;

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
			bool canSpawn = TrySpawnTetromino();

			if (!canSpawn)
				OntSwitchFailed?.Invoke();
		}

		private bool TrySpawnTetromino()
		{
			bool isValid = _grid.IsValidTetrominoPosition(
				_container.CurrentTetromino,
				_grid.SpawnPosition);

			if (isValid)
				SpawnTetromino();

			return isValid;
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
