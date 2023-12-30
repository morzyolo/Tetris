using Tetrominoes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TetrominoGridHandlers
{
	public class TetrominoGrid : MonoBehaviour
	{
		[SerializeField] private Tilemap _tilemap;
		[SerializeField] private GridSetup _gridSetup;

		[Header("Grid stats")]
		[SerializeField] private Vector2Int _gridSize = new(10, 18);
		[SerializeField] private Vector2Int _spawnPosition = new(5, 16);

		private void Awake()
		{
			_gridSetup.ResizeGrid(_gridSize);
		}

		public void SpawnTetromino(Tetromino tetromino)
		{
			tetromino.Position = _spawnPosition;
			PlaceTetrominoTiles(tetromino, tetromino.Tile);
		}

		public bool IsValidTetrominoPosition(Vector2Int position, Tetromino tetromino)
		{
			for (int i = 0; i < tetromino.Cells.Length; i++)
			{
				var tilePosition = tetromino.Cells[i] + position;

				if (!IsContainsPosition(tilePosition))
					return false;

				if (_tilemap.HasTile((Vector3Int)tilePosition))
					return false;
			}

			return true;
		}

		public void ClearTetrominoTiles(Tetromino tetromino)
			=> PlaceTetrominoTiles(tetromino, null);

		public void PlaceTetromino(Tetromino tetromino)
			=> PlaceTetrominoTiles(tetromino, tetromino.Tile);

		private void PlaceTetrominoTiles(Tetromino tetromino, Tile tile)
		{
			for (int i = 0; i < tetromino.Cells.Length; i++)
				_tilemap.SetTile(
					(Vector3Int)(tetromino.Cells[i] + tetromino.Position),
					tile);
		}

		private bool IsContainsPosition(Vector2Int position)
			=> position.x >= 0 && position.x < _gridSize.x
				&& position.y >= 0 && position.y < _gridSize.y;
	}
}
