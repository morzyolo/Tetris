using System;

namespace GameStateMachine.States
{
	public abstract class State
	{
		public event Action OnEntered;
		public event Action OnExited;

		protected readonly StateMachine StateMachine;

		protected State(StateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public void Enter()
		{
			OnEntered?.Invoke();
		}

		public void Exit()
		{
			OnExited.Invoke();
		}

		public abstract void SetNextState();
		public abstract void GoToNext();
	}
}