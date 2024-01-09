using UnityEngine.InputSystem;

namespace TetrominoHandlers
{
	public class Control
	{
		private readonly Rotator _rotator;
		private readonly HorizontalMover _mover;
		private readonly HardDropper _dropper;

		public Control(HorizontalMover mover, Rotator rotator, HardDropper dropper)
		{
			_rotator = rotator;
			_mover = mover;
			_dropper = dropper;
		}

		public void Move(InputAction.CallbackContext context)
			=> _mover.Move(context.ReadValue<float>());

		public void Rotate(InputAction.CallbackContext context)
			=> _rotator.Rotate(context.ReadValue<float>());

		public void HardDrop(InputAction.CallbackContext context)
			=> _ = _dropper.Drop();
	}
}