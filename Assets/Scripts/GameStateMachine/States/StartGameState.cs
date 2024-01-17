namespace GameStateMachine.States
{
	public sealed class StartGameState : State
	{
		private readonly State _nextState;

		public StartGameState(StateMachine stateMachine) : base(stateMachine)
		{
			_nextState = stateMachine.ResolveState<InGameState>();
		}

		public override void GoToNext()
		{
			StateMachine.ChangeState(this, _nextState);
		}
	}
}