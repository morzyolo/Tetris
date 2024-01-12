namespace TetrominoHandlers
{
	public class MoveDelayScaler
	{
		private readonly float _defaultDelayScale = 1f;
		private readonly float _acceleratedDelayScale = 0.2f;

		private readonly PeriodicDownMover _mover;

		public MoveDelayScaler(PeriodicDownMover mover)
		{
			_mover = mover;
		}

		public void SetDefaultDelay()
			=> _mover.ScaleMoveDelay(_defaultDelayScale);

		public void SetAcceleratedDelay()
			=> _mover.ScaleMoveDelay(_acceleratedDelayScale);
	}
}