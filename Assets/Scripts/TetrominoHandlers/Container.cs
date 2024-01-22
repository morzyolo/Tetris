using Configs;
using System;
using Tetrominoes;

namespace TetrominoHandlers
{
	public class Container
	{
		public event Action<Tetromino> OnLanded;

		public float TimeToLock { get; set; } = 0f;

		private readonly TetrominoMovementConfig _config;

		public Container(TetrominoMovementConfig config)
		{
			_config = config;
		}

		public Tetromino CurrentTetromino => _currentTetramino;
		private Tetromino _currentTetramino;

		public void SetTimeToLock() => TimeToLock = _config.TimeToLock;

		public void SwitchTetromino(Tetromino newTetromino)
			=> _currentTetramino = newTetromino;

		public void Land() => OnLanded?.Invoke(_currentTetramino);
	}
}