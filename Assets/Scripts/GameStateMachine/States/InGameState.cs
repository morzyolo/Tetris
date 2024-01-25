namespace GameStateMachine.States
{
	public sealed class InGameState : State
	{
		private State _nextState;

		public InGameState(StateMachine stateMachine)
			: base(stateMachine) { }

		public override void SetNextState()
			=> _nextState = StateMachine.ResolveState<EndGameState>();

		public override void GoToNext()
		{
			StateMachine.ChangeState(this, _nextState);
		}
	}
}
