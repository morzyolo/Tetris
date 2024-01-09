using Tetrominoes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TetrominoGridHandlers
{
	public class TetrominoGrid : MonoBehaviour
	{
		public Vector2Int GridSize => _gridSize;
		public Vector2Int SpawnPosition => _spawnPosition;

		[SerializeField] private Tilemap _tilemap;
		[SerializeField] private GridSetup _gridSetup;

		[Header("Grid stats")]
		[SerializeField] private Vector2Int _gridSize = new(10, 18);
		[SerializeField] private Vector2Int _spawnPosition = new(4, 16);

		private GridRowCleaner _rowCleaner;

		private void Awake()
		{
			_gridSetup.ResizeGrid(_gridSize);
			_rowCleaner = new(this, _tilemap);
		}

		public void ClearRows() => _rowCleaner.ClearRows();

		public void PlaceTetromino(Tetromino tetromino)
			=> PlaceTetrominoTiles(tetromino, tetromino.Data.Tile);

		public void ClearTetrominoTiles(Tetromino tetromino)
			=> PlaceTetrominoTiles(tetromino, null);

		public bool IsValidTetrominoPosition(Tetromino tetromino, Vector2Int position)
		{
			Vector2Int[] cells = tetromino.Data.Cells;

			for (int i = 0; i < cells.Length; i++)
			{
				var tilePosition = cells[i] + position;

				if (!IsContainsPosition(tilePosition))
					return false;

				if (_tilemap.HasTile((Vector3Int)tilePosition))
					return false;
			}

			return true;
		}

		private void PlaceTetrominoTiles(Tetromino tetromino, Tile tile)
		{
			Vector2Int[] cells = tetromino.Data.Cells;

			for (int i = 0; i < cells.Length; i++)
				_tilemap.SetTile(
					(Vector3Int)(cells[i] + tetromino.Position),
					tile);
		}

		private bool IsContainsPosition(Vector2Int position)
			=> position.x >= 0 && position.x < _gridSize.x
				&& position.y >= 0 && position.y < _gridSize.y;
	}
}
