using Configs;

namespace TetrominoHandlers
{
	public class MoveDelayMultiplier
	{
		private readonly PeriodicDownMover _mover;
		private readonly TetrominoMovementConfig _config;

		public MoveDelayMultiplier(PeriodicDownMover mover, TetrominoMovementConfig config)
		{
			_mover = mover;
			_config = config;
		}

		public void SetDefaultDelay()
			=> _mover.ScaleMoveDelay(_config.DefaultMoveDelayMultiplier);

		public void SetAcceleratedDelay()
			=> _mover.ScaleMoveDelay(_config.AcceleratedDelayMultiplier);
	}
}
