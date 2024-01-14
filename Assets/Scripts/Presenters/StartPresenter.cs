using InputHandlers;
using System;
using TetrominoHandlers;
using Views;

namespace Presenters
{
	public sealed class StartPresenter : IDisposable
	{
		private readonly StartView _view;
		private readonly Control _control;
		private readonly Switcher _switcher;
		private readonly InputHandler _input;

		public StartPresenter(
			StartView view,
			Control control,
			Switcher switcher,
			InputHandler input
		)
		{
			_view = view;
			_switcher = switcher;
			_control = control;
			_input = input;

			_input.Disable();
			_view.OnPlayButtonPressed += StartGame;
		}

		public void Dispose()
		{
			_view.OnPlayButtonPressed -= StartGame;
		}

		private void StartGame()
		{
			_switcher.SpawnTetromino();
			_ = _control.StartMove();
		}
	}
}
