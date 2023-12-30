using TetrominoGridHandlers;

namespace TetrominoHandlers
{
	public class Rotator
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;

		public Rotator(TetrominoGrid grid, Container tetramino)
		{
			_grid = grid;
			_container = tetramino;
		}

		public void Rotate(float direction)
		{
			_grid.ClearTetrominoTiles(_container.CurrentTetromino);
			_container.CurrentTetromino.Rotate(direction);
			_grid.PlaceTetromino(_container.CurrentTetromino);
		}
	}
}