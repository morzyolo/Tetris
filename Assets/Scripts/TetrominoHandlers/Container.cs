using Tetrominoes;

namespace TetrominoHandlers
{
	public class Container
	{
		public Tetromino CurrentTetromino => _currentTetramino;
		private Tetromino _currentTetramino;

		public Container(Tetromino startTetromino)
			=> SwitchTetromino(startTetromino);

		public void SwitchTetromino(Tetromino newTetromino)
			=> _currentTetramino = newTetromino;
	}
}