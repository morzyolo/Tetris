using Cysharp.Threading.Tasks;

namespace TetrominoHandlers
{
	public class HardDropper
	{
		private readonly DownMover _downMover;

		public HardDropper(DownMover downMover)
		{
			_downMover = downMover;
		}

		public async UniTaskVoid Drop()
		{
			while (_downMover.TryMoveDown())
				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
		}
	}
}
