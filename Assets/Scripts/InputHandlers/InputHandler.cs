using System;
using TetrominoHandlers;

namespace InputHandlers
{
	public sealed class InputHandler : IDisposable
	{
		private readonly Control _control;
		private readonly InputMap _input;

		public InputHandler(Control control)
		{
			_input = new InputMap();
			Enable();

			_control = control;
			Sub();
		}

		public void Enable() => _input.Enable();

		public void Disable() => _input.Disable();

		public void Dispose()
		{
			Unsub();
			Disable();
			_input.Dispose();
		}

		private void Sub()
		{
			_input.TetrominoControl.Moved.started += _control.Move;
			_input.TetrominoControl.Rotated.started += _control.Rotate;
			_input.TetrominoControl.HardDrop.started += _control.HardDrop;
			_input.TetrominoControl.DownMove.started += _control.MoveDown;
			_input.TetrominoControl.DownMove.canceled += _control.MoveDown;
		}

		private void Unsub()
		{
			_input.TetrominoControl.Moved.started -= _control.Move;
			_input.TetrominoControl.Rotated.started -= _control.Rotate;
			_input.TetrominoControl.HardDrop.started -= _control.HardDrop;
			_input.TetrominoControl.DownMove.started -= _control.MoveDown;
			_input.TetrominoControl.DownMove.canceled -= _control.MoveDown;
		}
	}
}
