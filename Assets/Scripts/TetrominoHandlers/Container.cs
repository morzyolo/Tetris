using Tetrominoes;

namespace TetrominoHandlers
{
	public class Container
	{
		private const int _rotationCount = 4;

		public int RotationIndex
		{
			get => _rotationIndex;
			private set => _rotationIndex = (value + _rotationCount) % _rotationCount;
		}
		private int _rotationIndex = 0;

		public Tetromino CurrentTetromino => _currentTetramino;
		private Tetromino _currentTetramino;

		public Container(Tetromino startTetromino)
			=> SwitchTetromino(startTetromino);

		public void SwitchTetromino(Tetromino newTetromino)
			=> _currentTetramino = newTetromino;
	}
}