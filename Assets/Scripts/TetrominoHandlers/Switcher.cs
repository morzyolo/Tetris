using GameStateMachine;
using GameStateMachine.States;
using Presenters;
using System;
using Tetrominoes;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public sealed class Switcher : IDisposable
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly TetrominoFactory _factory;
		private readonly StartPresenter _presenter;
		private readonly State _state;

		public Switcher(
			TetrominoGrid grid,
			Container container,
			TetrominoFactory factory,
			StartPresenter presenter,
			StateMachine stateMachine
		)
		{
			_grid = grid;
			_container = container;
			_factory = factory;
			_presenter = presenter;
			_state = stateMachine.ResolveState<InGameState>();

			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;
		}

		private void Enable()
		{
			_container.OnLanded += SwitchTetromino;

			_factory.ChangeSeed(_presenter.Seed);
			_container.SwitchTetromino(_factory.Produce());
			SpawnTetromino();
		}

		private void Disable()
		{
			_container.OnLanded -= SwitchTetromino;
		}

		private void SwitchTetromino(Tetromino _)
		{
			_container.SwitchTetromino(_factory.Produce());
			bool canSpawn = TrySpawnTetromino();

			if (!canSpawn)
				_state.GoToNext();
		}

		private bool TrySpawnTetromino()
		{
			bool isValid = _grid.IsValidTetrominoPosition(
				_container.CurrentTetromino,
				_grid.SpawnPosition
			);

			if (isValid)
				SpawnTetromino();

			return isValid;
		}

		private void SpawnTetromino()
		{
			_container.CurrentTetromino.Position = _grid.SpawnPosition;
			_grid.PlaceTetromino(_container.CurrentTetromino);
		}
	}
}
