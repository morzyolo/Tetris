using System;
using Tetrominoes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TetrominoGridHandlers
{
	public class TetrominoGrid : MonoBehaviour
	{
		public event Action OnRowCleared
		{
			add => _rowCleaner.OnRowCleared += value;
			remove => _rowCleaner.OnRowCleared -= value;
		}

		public RectInt GridBoundary => _gridBoundary;

		[SerializeField] private Tilemap _tilemap;
		[SerializeField] private GridSetup _gridSetup;

		[Header("Grid stats")]
		[SerializeField] private Vector2Int _gridSize = new(10, 18);
		[SerializeField] private int _limitHeight = 16;

		private RectInt _gridBoundary;
		private GridRowCleaner _rowCleaner;

		private void Awake()
		{
			_gridSetup.Setup(_gridSize, _limitHeight);
		}

		public void Init()
		{
			_gridBoundary = new(0, 0, _gridSize.x, _gridSize.y);
			_rowCleaner = new(this, _tilemap);
		}

		public void ClearRows(Tetromino tetromino)
			=> _rowCleaner.ClearRows(tetromino);

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

				if (!IsValid(tilePosition))
					return false;

				if (_tilemap.HasTile((Vector3Int)tilePosition))
					return false;
			}

			return true;
		}

		public bool IsInsideLimitGrid(Tetromino tetromino, Vector2Int position)
		{
			Vector2Int[] cells = tetromino.Data.Cells;

			for (int i = 0; i < cells.Length; i++)
			{
				if (!IsInsideLimitGrid(cells[i] + position))
					return false;
			}

			return true;
		}

		public bool HasTilesInLimitArea()
		{
			for (int y = _limitHeight; y < _gridBoundary.yMax; y++)
			{
				for (int x = _gridBoundary.xMin; x < _gridBoundary.xMax; x++)
				{
					if (_tilemap.HasTile(new(x, y)))
						return true;
				}
			}

			return false;
		}

		private bool IsInsideLimitGrid(Vector2Int position)
			=> IsValid(position) && position.y < _limitHeight;

		private void PlaceTetrominoTiles(Tetromino tetromino, Tile tile)
		{
			Vector2Int[] cells = tetromino.Data.Cells;

			for (int i = 0; i < cells.Length; i++)
			{
				var position = cells[i] + tetromino.Position;

				if (IsInsideGrid(position))
					_tilemap.SetTile((Vector3Int)position, tile);
			}
		}

		private bool IsInsideGrid(Vector2Int position)
			=> _gridBoundary.Contains(position);

		private bool IsValid(Vector2Int position)
			=> position.x >= _gridBoundary.xMin
			&& position.x < _gridBoundary.xMax
			&& position.y >= _gridBoundary.yMin;
	}
}
