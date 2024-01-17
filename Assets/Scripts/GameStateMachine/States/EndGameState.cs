namespace GameStateMachine.States
{
	public sealed class EndGameState : State
	{
		private readonly State _nextState;

		public EndGameState(StateMachine stateMachine) : base(stateMachine)
		{
			_nextState = stateMachine.ResolveState<StartGameState>();
		}

		public override void GoToNext()
		{
			StateMachine.ChangeState(this, _nextState);
		}
	}
}