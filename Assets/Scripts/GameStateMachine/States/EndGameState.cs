namespace GameStateMachine.States
{
	public sealed class EndGameState : State
	{
		private State _nextState;

		public EndGameState(StateMachine stateMachine)
			: base(stateMachine) { }

		public override void SetNextState()
			=> _nextState = StateMachine.ResolveState<StartGameState>();

		public override void GoToNext()
		{
			StateMachine.ChangeState(this, _nextState);
		}
	}
}
