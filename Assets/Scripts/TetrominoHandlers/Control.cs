using Configs;
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
		private readonly MoveDelayMultiplier _moveDelayMultiplier;

		private readonly State _state;

		public Control(
			TetrominoGrid grid,
			Container container,
			StateMachine stateMachine,
			TetrominoMovementConfig config)
		{
			Mover mover = new(grid, container);
			_rotator = new(grid, container);
			_horizontalMover = new(mover, container, config);
			_periodicMover = new(mover, grid, container, config);

			_dropper = new(_periodicMover);
			_moveDelayMultiplier = new(_periodicMover, config);

			_state = stateMachine.ResolveState<InGameState>();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		public void Move(InputAction.CallbackContext context)
		{
			if (context.started)
				_horizontalMover.Start(context.ReadValue<float>());

			if (context.canceled)
				_horizontalMover.Stop();
		}

		public void Rotate(InputAction.CallbackContext context)
			=> _rotator.Rotate(context.ReadValue<float>());

		public void HardDrop(InputAction.CallbackContext _)
			=> _dropper.Drop().Forget();

		public void MoveDown(InputAction.CallbackContext context)
		{
			bool isStarted = context.ReadValueAsButton();

			if (isStarted)
				_moveDelayMultiplier.SetAcceleratedDelay();
			else
				_moveDelayMultiplier.SetDefaultDelay();
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
			_horizontalMover.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
