using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class HorizontalMover
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _tetramino;

		public HorizontalMover(TetrominoGrid grid, Container tetramino)
		{
			_grid = grid;
			_tetramino = tetramino;
		}

		public void Move(float direction)
		{
			//TODO
		}
	}
}
