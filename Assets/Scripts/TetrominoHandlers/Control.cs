using Cysharp.Threading.Tasks;
using GameStates;
using TetrominoGridHandlers;
using UnityEngine.InputSystem;

namespace TetrominoHandlers
{
	public class Control
	{
		private readonly Rotator _rotator;
		private readonly HardDropper _dropper;
		private readonly HorizontalMover _horizontalMover;
		private readonly PeriodicDownMover _periodicMover;
		private readonly MoveDelayScaler _moveDelayScaler;

		public Control(TetrominoGrid grid, Container container, GameState gameState)
		{
			Mover mover = new(grid, container);
			_rotator = new(grid, container);
			_horizontalMover = new(mover, container);
			_periodicMover = new(grid, container, gameState,  mover); // TODO: dispose

			_dropper = new(_periodicMover);
			_moveDelayScaler = new(_periodicMover);
		}

		public void Move(InputAction.CallbackContext context)
			=> _horizontalMover.Move(context.ReadValue<float>());

		public void Rotate(InputAction.CallbackContext context)
			=> _rotator.Rotate(context.ReadValue<float>());

		public void HardDrop(InputAction.CallbackContext context)
			=> _ = _dropper.Drop();

		public void MoveDown(InputAction.CallbackContext context)
		{
			bool isStarted = context.ReadValueAsButton();

			if (isStarted)
				_moveDelayScaler.SetAcceleratedDelay();
			else
				_moveDelayScaler.SetDefaultDelay();
		}

		public UniTaskVoid StartMove() => _periodicMover.Move();
	}
}