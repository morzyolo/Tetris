namespace TetrominoHandlers
{
	public class HardDropper
	{
		private readonly PeriodicDownMover _downMover;

		public HardDropper(PeriodicDownMover downMover)
		{
			_downMover = downMover;
		}

		public void Drop()
		{
			while (_downMover.TryMoveDown())
			{ }

			_downMover.Lock();
		}
	}
}
