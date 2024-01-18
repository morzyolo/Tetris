using GameStateMachine;
using GameStateMachine.States;
using System;
using TetrominoGridHandlers;
using UnityEngine.InputSystem;

namespace TetrominoHandlers
{
	public sealed class Control : IDisposable
	{
		private readonly Rotator _rotator;
		private readonly HardDropper _dropper;
		private readonly HorizontalMover _horizontalMover;
		private readonly PeriodicDownMover _periodicMover;
		private readonly MoveDelayScaler _moveDelayScaler;

		private readonly State _state;

		public Control(TetrominoGrid grid, Container container, StateMachine stateMachine)
		{
			Mover mover = new(grid, container);
			_rotator = new(grid, container);
			_horizontalMover = new(mover, container);
			_periodicMover = new(grid, container, mover);

			_dropper = new(_periodicMover);
			_moveDelayScaler = new(_periodicMover);

			_state = stateMachine.ResolveState<InGameState>();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
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

		private void Enable()
		{
			_periodicMover.Start();
		}

		private void Disable()
		{
			_periodicMover.Stop();
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;

			_periodicMover.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}