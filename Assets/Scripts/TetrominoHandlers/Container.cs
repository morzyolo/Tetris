using Tetrominoes;

namespace TetrominoHandlers
{
	public class Container
	{
		public ITetromino CurrentTetromino => _currentTetramino;
		private ITetromino _currentTetramino;

		public Container(ITetromino startTetromino)
			=> SwitchTetromino(startTetromino);

		public void SwitchTetromino(ITetromino newTetromino)
			=> _currentTetramino = newTetromino;
	}
}