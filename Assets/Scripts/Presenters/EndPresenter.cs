using GameStateMachine;
using GameStateMachine.States;
using Models;
using System;
using UnityEngine.SceneManagement;
using Views;

namespace Presenters
{
	public sealed class EndPresenter : IDisposable
	{
		private readonly EndView _view;
		private readonly Score _score;
		private readonly State _state;

		public EndPresenter(EndView view, Score score, StateMachine stateMachine)
		{
			_view = view;
			_score = score;
			_state = stateMachine.ResolveState<EndGameState>();

			_view.Hide();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		private void Enable()
		{
			_view.Show();
			_view.SetScore(_score.CurrentScore);
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
			int sceneId = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(sceneId);
		}
	}
}
