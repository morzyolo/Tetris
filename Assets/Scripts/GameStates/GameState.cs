using System;
using TetrominoHandlers;

namespace GameStates
{
	public sealed class GameState : IDisposable
	{
		public bool IsPlaying { get; private set; } = true;

		private readonly Switcher _switcher;

		public GameState(Switcher switcher)
		{
			_switcher = switcher;

			_switcher.OntSwitchFailed += ShangeState;
		}

		public void Dispose()
		{
			_switcher.OntSwitchFailed -= ShangeState;
		}

		private void ShangeState()
		{
			IsPlaying = false;
		}
	}
}