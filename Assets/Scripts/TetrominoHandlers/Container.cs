using System;
using Tetrominoes;

namespace TetrominoHandlers
{
	public class Container
	{
		public event Action OnLanded;

		public float TimeToLock { get; set; } = 0f;

		private readonly float _defaultTimeToLock = 0.2f;

		public Tetromino CurrentTetromino => _currentTetramino;
		private Tetromino _currentTetramino;

		public Container(Tetromino startTetromino)
			=> SwitchTetromino(startTetromino);

		public void SetTimeToLock() => TimeToLock = _defaultTimeToLock;

		public void SwitchTetromino(Tetromino newTetromino)
			=> _currentTetramino = newTetromino;

		public void Land() => OnLanded?.Invoke();
	}
}