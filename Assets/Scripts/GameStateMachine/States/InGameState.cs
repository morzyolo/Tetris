namespace GameStateMachine.States
{
	public sealed class InGameState : State
	{
		private readonly State _nextState;

		public InGameState(StateMachine stateMachine) : base(stateMachine)
		{
			_nextState = stateMachine.ResolveState<EndGameState>();
		}

		public override void GoToNext()
		{
			StateMachine.ChangeState(this, _nextState);
		}
	}
}