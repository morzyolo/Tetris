using GameStateMachine;
using GameStateMachine.States;
using System;
using TetrominoHandlers;

namespace InputHandlers
{
	public sealed class InputHandler : IDisposable
	{
		private readonly InputMap _input;
		private readonly Control _control;
		private readonly State _state;

		public InputHandler(Control control, StateMachine stateMachine)
		{
			_input = new();
			_control = control;
			_state = stateMachine.ResolveState<InGameState>();

			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		public void Enable()
		{
			Sub();
			_input.Enable();
		}

		public void Disable()
		{
			Unsub();
			_input.Disable();
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;

			Disable();
			_input.Dispose();
		}

		private void Sub()
		{
			_input.TetrominoControl.Moved.started += _control.Move;
			_input.TetrominoControl.Moved.canceled += _control.Move;
			_input.TetrominoControl.Rotated.started += _control.Rotate;
			_input.TetrominoControl.HardDrop.started += _control.HardDrop;
			_input.TetrominoControl.DownMove.started += _control.MoveDown;
			_input.TetrominoControl.DownMove.canceled += _control.MoveDown;
		}

		private void Unsub()
		{
			_input.TetrominoControl.Moved.started -= _control.Move;
			_input.TetrominoControl.Moved.canceled -= _control.Move;
			_input.TetrominoControl.Rotated.started -= _control.Rotate;
			_input.TetrominoControl.HardDrop.started -= _control.HardDrop;
			_input.TetrominoControl.DownMove.started -= _control.MoveDown;
			_input.TetrominoControl.DownMove.canceled -= _control.MoveDown;
		}
	}
}
