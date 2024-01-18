using GameStateMachine;
using GameStateMachine.States;
using Models;
using System;
using Views;

namespace Controllers
{
	public sealed class ScoreController : IDisposable
	{
		private readonly ScoreView _view;
		private readonly Score _score;

		private readonly State _state;

		public ScoreController(ScoreView view, Score score, StateMachine stateMachine)
		{
			_view = view;
			_score = score;
			_state = stateMachine.ResolveState<InGameState>();

			Disable();
			_score.OnValueChanged += ChangeScore;
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		public void Dispose()
		{
			_score.OnValueChanged -= ChangeScore;
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;
		}

		private void ChangeScore(int score)
		{
			_view.UpdateScore(score);
		}

		private void Enable()
		{
			_view.Show();
			_score.Reset();
			int score = _score.CurrentScore;
			_view.UpdateScore(score);
		}

		private void Disable()
		{
			_view.Hide();
		}
	}
}