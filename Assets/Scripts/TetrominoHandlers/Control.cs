using UnityEngine.InputSystem;

namespace TetrominoHandlers
{
	public class Control
	{
		private readonly Rotator _rotator;
		private readonly HorizontalMover _mover;

		public Control(HorizontalMover mover, Rotator rotator)
		{
			_rotator = rotator;
			_mover = mover;
		}

		public void Move(InputAction.CallbackContext context)
			=> _mover.Move(context.ReadValue<float>());

		public void Rotate(InputAction.CallbackContext context)
			=> _rotator.Rotate(context.ReadValue<float>());
	}
}