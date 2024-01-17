using GameStateMachine;
using GameStateMachine.States;
using System;
using Views;

namespace Presenters
{
	public sealed class StartPresenter : IDisposable
	{
		private readonly StartView _view;
		private readonly State _state;

		public StartPresenter(StartView view, StateMachine stateMachine)
		{
			_view = view;
			_state = stateMachine.ResolveState<StartGameState>();

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

		private void StartGame(int seed)
		{
			_state.GoToNext();
		}
	}
}
