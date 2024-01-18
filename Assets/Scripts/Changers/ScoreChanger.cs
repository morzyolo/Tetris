using Models;
using System;
using Tetrominoes;
using TetrominoGridHandlers;
using TetrominoHandlers;
using UnityEngine;

namespace Changers
{
	public sealed class ScoreChanger : IDisposable
	{
		private readonly TetrominoGrid _grid;
		private readonly Container _container;
		private readonly Score _score;

		public ScoreChanger(TetrominoGrid grid, Container container, Score score)
		{
			_grid = grid;
			_container = container;
			_score = score;

			_grid.OnRowCleared += AddScoreForRow;
			_container.OnLanded += AddScoreForTetromino;
		}

		public void Dispose()
		{
			_grid.OnRowCleared -= AddScoreForRow;
			_container.OnLanded -= AddScoreForTetromino;
		}

		private void AddScoreForRow()
		{
			RectInt gridBoundary = _grid.GridBoundary;
			AddScore(gridBoundary.width);
		}

		private void AddScoreForTetromino(Tetromino tetromino)
		{
			AddScore(tetromino.Data.Cells.Length);
		}

		private void AddScore(int score)
			=> _score.AddScore(score);
	}
}