using Cysharp.Threading.Tasks;
using GameStateMachine.States;
using System;
using System.Collections.Generic;

namespace GameStateMachine
{
	public class StateMachine
	{
		private readonly Dictionary<Type, State> _states;

		private State _currentState;

		public StateMachine()
		{
			_states = new()
			{
				{ typeof(StartGameState), new StartGameState(this) },
				{ typeof(InGameState), new InGameState(this) },
				{ typeof(EndGameState), new EndGameState(this) }
			};

			foreach (var state in _states.Values)
				state.SetNextState();

			_currentState = _states[typeof(StartGameState)];
		}

		public void Init()
		{
			_currentState.Enter();
		}

		public S ResolveState<S>()
			where S : State
		{
			if (_states.TryGetValue(typeof(S), out var state))
				return (S)state;

			throw new KeyNotFoundException("State not found");
		}

		public async UniTaskVoid ChangeState(State currentState, State nextState)
		{
			await currentState.Exit();
			_currentState = nextState;
			_currentState.Enter();
		}
	}
}
