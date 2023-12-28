using System;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class Switcher : IDisposable
	{
		private readonly TetrominoFactory _factory;
		private readonly DownMover _downMover;

		public Switcher(TetrominoFactory factory, DownMover downMover)
		{
			_factory = factory;
			_downMover = downMover;

			_downMover.TetrominoPlaced += ChangeTetromino;
		}

		private void ChangeTetromino()
		{
			//TODO
		}

		public void Dispose()
		{
			_downMover.TetrominoPlaced -= ChangeTetromino;
		}
	}
}