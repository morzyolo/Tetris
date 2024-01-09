using UnityEngine;

namespace TetrominoHandlers
{
	public class HorizontalMover
	{
		private readonly Mover _mover;

		public HorizontalMover(Mover mover)
		{
			_mover = mover;
		}

		public void Move(float direction)
			=> _mover.TryTranslateTetromino(direction < 0 ? Vector2Int.left : Vector2Int.right);
	}
}
