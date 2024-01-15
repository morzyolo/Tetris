using InputHandlers;
using System;
using TetrominoHandlers;
using UnityEngine.SceneManagement;
using Views;

namespace Presenters
{
	public sealed class EndPresenter : IDisposable
	{
		private readonly EndView _view;
		private readonly InputHandler _input;
		private readonly Switcher _switcher;

		public EndPresenter(
			EndView view,
			Switcher switcher,
			InputHandler input
		)
		{
			_view = view;
			_input = input;
			_switcher = switcher;

			_view.Hide();
			_switcher.OntSwitchFailed += Show;
			_view.OnRestartButtonPressed += RestartGame;
		}

		public void Dispose()
		{
			_switcher.OntSwitchFailed -= Show;
			_view.OnRestartButtonPressed -= RestartGame;
		}

		private void Show()
		{
			_input.Disable();
			_view.Show();
		}

		private void RestartGame()
		{
			int sceneId = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(sceneId);
		}
	}
}
