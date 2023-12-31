using System;
using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class Switcher : IDisposable
	{
		private readonly Container _container;
		private readonly DownMover _downMover;
		private readonly TetrominoFactory _factory;

		public Switcher(Container container, TetrominoFactory factory, DownMover downMover)
		{
			_container = container;
			_downMover = downMover;
			_factory = factory;

			_downMover.TetrominoPlaced += SwitchTetromino;
		}

		private void SwitchTetromino()
			=> _container.SwitchTetromino(_factory.Produce());

		public void Dispose()
		{
			_downMover.TetrominoPlaced -= SwitchTetromino;
		}
	}
}