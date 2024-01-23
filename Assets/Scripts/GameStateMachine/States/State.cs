using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GameStateMachine.States
{
	public abstract class State
	{
		public event Action OnEntered;
		public event Action OnExited;

		protected readonly StateMachine StateMachine;

		private readonly List<Func<UniTask>> _exitTasks = new();

		protected State(StateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public void Enter()
		{
			OnEntered?.Invoke();
		}

		public async UniTask Exit()
		{
			await InvokeTasks(_exitTasks);
			OnExited.Invoke();
		}

		public void AddExitTask(Func<UniTask> task)
		{
			_exitTasks.Add(task);
		}

		public abstract void SetNextState();
		public abstract void GoToNext();

		private async UniTask InvokeTasks(List<Func<UniTask>> taskList)
		{
			var tasks = new UniTask[taskList.Count];
			for (int i = 0; i < tasks.Length; i++)
				tasks[i] = taskList[i].Invoke();

			await UniTask.WhenAll(tasks);
		}
	}
}