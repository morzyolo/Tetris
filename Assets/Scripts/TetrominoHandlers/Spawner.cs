using Extensions;
using Tetrominoes;
using TetrominoGridHandlers;
using UnityEngine;

namespace TetrominoHandlers
{
	public class Spawner
	{
		private readonly TetrominoGrid _grid;
		private readonly Vector2Int _defaultSpawnPosition;

		public Spawner(TetrominoGrid grid)
		{
			_grid = grid;

			_defaultSpawnPosition = new(
				_grid.GridBoundary.width / 2,
				_grid.GridBoundary.height);
		}

		public void Spawn(Tetromino tetromino)
		{
			Vector2Int spawnPosition = _defaultSpawnPosition;
			spawnPosition.y += tetromino.Height() / 2;

			tetromino.Position = spawnPosition;
			_grid.PlaceTetromino(tetromino);
		}
	}
}
