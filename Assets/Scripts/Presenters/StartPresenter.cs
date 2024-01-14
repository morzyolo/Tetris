using InputHandlers;
using System;
using TetrominoHandlers;
using UnityEngine;
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

		private void StartGame(int seed)
		{
			_view.Hide();
			_input.Enable();
			_switcher.SpawnInitialTetromino(seed);
			_ = _control.StartMove();
		}
	}
}
