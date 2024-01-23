using Extensions;
using GameStateMachine;
using GameStateMachine.States;
using Presenters;
using System;
using Tetrominoes;
using TetrominoGridHandlers;
using UnityEngine;

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
			SpawnTetromino();
		}

		private void Disable()
		{
			_container.OnLanded -= SwitchTetromino;
		}

		private void SwitchTetromino(Tetromino tetromino)
		{
			if (_grid.HasTilesInLimitArea())
			{
				_state.GoToNext();
				return;
			}

			SpawnTetromino();
		}

		private void SpawnTetromino()
		{
			Tetromino newTetromino = _factory.Produce();
			_container.SwitchTetromino(newTetromino);

			Vector2Int spawnPosition = GetSpawnTetrominoPosition();
			_container.CurrentTetromino.Position = spawnPosition;
			_grid.PlaceTetromino(_container.CurrentTetromino);
		}

		private Vector2Int GetSpawnTetrominoPosition()
		{
			int tetrominoHeight = _container.CurrentTetromino.Height();
			return new(
				_grid.GridBoundary.width / 2,
				_grid.GridBoundary.height + tetrominoHeight / 2);
		}
	}
}
