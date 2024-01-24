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
		private readonly Spawner _spawner;
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly TetrominoFactory _factory;
		private readonly StartPresenter _presenter;
		private readonly State _state;

		public Switcher(
			Spawner spawner,
			TetrominoGrid grid,
			Container container,
			TetrominoFactory factory,
			StartPresenter presenter,
			StateMachine stateMachine)
		{
			_spawner = spawner;
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
			_container.OnLanded += Handle;

			_factory.ChangeSeed(_presenter.Seed);
			Switch();
		}

		private void Disable()
		{
			_container.OnLanded -= Handle;
		}

		private void Handle(Tetromino tetromino)
		{
			if (_grid.HasTilesInLimitArea())
			{
				_state.GoToNext();
				return;
			}

			Switch();
		}

		private void Switch()
		{
			Tetromino newTetromino = _factory.Produce();
			_container.SwitchTetromino(newTetromino);
			_spawner.Spawn(newTetromino);
		}
	}
}
