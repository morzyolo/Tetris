﻿using GameStateMachine;
using GameStateMachine.States;
using System;
using Views;

namespace Presenters
{
	public sealed class EndPresenter : IDisposable
	{
		private readonly EndView _view;
		private readonly State _state;

		public EndPresenter(EndView view, StateMachine stateMachine)
		{
			_view = view;
			_state = stateMachine.ResolveState<EndGameState>();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		private void Enable()
		{
			_view.Show();
			_view.OnRestartButtonPressed += RestartGame;
		}

		private void Disable()
		{
			_view.OnRestartButtonPressed -= RestartGame;
			_view.Hide();
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;
		}

		private void RestartGame()
		{
			_state.GoToNext();
		}
	}
}
