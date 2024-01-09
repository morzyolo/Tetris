using TetrominoHandlers;
using UnityEngine;

namespace InputHandlers
{
	public class InputHandler : MonoBehaviour
	{
		private Control _control;
		private InputMap _input;

		public void Init(Control control)
		{
			_input = new InputMap();
			_input.Enable();

			_control = control;
			Sub();
		}

		private void Sub()
		{
			_input.TetrominoControl.Moved.started += _control.Move;
			_input.TetrominoControl.Rotated.started += _control.Rotate;
			_input.TetrominoControl.HardDrop.started += _control.HardDrop;
		}

		private void Unsub()
		{
			_input.TetrominoControl.Moved.started -= _control.Move;
			_input.TetrominoControl.Rotated.started -= _control.Rotate;
			_input.TetrominoControl.HardDrop.started -= _control.HardDrop;
		}

		private void OnDisable()
		{
			Unsub();
			_input.Disable();
			_input.Dispose();
		}
	}
}
