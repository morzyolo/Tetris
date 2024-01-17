using GameStateMachine;
using GameStateMachine.States;
using System;
using Views;

namespace Presenters
{
	public sealed class StartPresenter : IDisposable
	{
		public int Seed => _view.Seed;

		private readonly StartView _view;
		private readonly State _state;

		public StartPresenter(StartView view, StateMachine stateMachine)
		{
			_view = view;
			_state = stateMachine.ResolveState<StartGameState>();

			_view.Show();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		private void Enable()
		{
			_view.Show();
			_view.OnPlayButtonPressed += StartGame;
		}

		private void Disable()
		{
			_view.OnPlayButtonPressed -= StartGame;
			_view.Hide();
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;
		}

		private void StartGame()
		{
			_state.GoToNext();
		}
	}
}
