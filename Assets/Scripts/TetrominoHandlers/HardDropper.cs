using Cysharp.Threading.Tasks;

namespace TetrominoHandlers
{
	public class HardDropper
	{
		private readonly PeriodicDownMover _downMover;

		public HardDropper(PeriodicDownMover downMover)
		{
			_downMover = downMover;
		}

		public async UniTaskVoid Drop()
		{
			while (_downMover.TryMoveDown())
				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);

			_downMover.Lock();
		}
	}
}
