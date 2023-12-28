using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class Rotator
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _tetramino;

		public Rotator(TetrominoGrid grid, Container tetramino)
		{
			_grid = grid;
			_tetramino = tetramino;
		}

		public void Rotate(float direction)
		{
			//TODO
		}
	}
}