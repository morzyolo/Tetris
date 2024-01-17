namespace GameStateMachine.States
{
	public sealed class StartGameState : State
	{
		private State _nextState;

		public StartGameState(StateMachine stateMachine)
			: base(stateMachine) { }

		public override void SetNextState()
			=> _nextState = StateMachine.ResolveState<InGameState>();

		public override void GoToNext()
		{
			StateMachine.ChangeState(this, _nextState);
		}
	}
}
