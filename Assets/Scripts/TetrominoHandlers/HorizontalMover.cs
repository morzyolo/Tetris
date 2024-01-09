using UnityEngine;

namespace TetrominoHandlers
{
	public class HorizontalMover
	{
		private readonly Mover _mover;
		private readonly Container _container;

		public HorizontalMover(Mover mover, Container container)
		{
			_mover = mover;
			_container = container;
		}

		public void Move(float direction)
		{
			bool canMove = _mover.TryTranslateTetromino(
				direction < 0 ? Vector2Int.left : Vector2Int.right);

			if (canMove)
				_container.SetTimeToLock();
		}
	}
}
