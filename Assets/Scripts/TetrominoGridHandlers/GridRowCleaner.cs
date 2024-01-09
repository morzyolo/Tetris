using UnityEngine;
using UnityEngine.Tilemaps;

namespace TetrominoGridHandlers
{
	internal class GridRowCleaner
	{
		private readonly TetrominoGrid _grid;
		private readonly Tilemap _tilemap;

		public GridRowCleaner(TetrominoGrid grid, Tilemap tilemap)
		{
			_grid = grid;
			_tilemap = tilemap;
		}

		public void ClearRows()
		{
			Vector2Int gridSize = _grid.GridSize;
			int row = 0;
			int rowShift = 0;

			while (row < gridSize.y)
			{
				if (IsLineFull(row, 0, gridSize.x))
					rowShift++;
				else
					ShiftRow(row, rowShift, 0, gridSize.x);

				row++;
			}

			if (rowShift > 0)
			{
				for (int y = gridSize.y - rowShift; y < gridSize.y; y++)
					for (int x = 0; x < gridSize.x; x++)
						_tilemap.SetTile(new(x, y), null);
			}
		}

		private bool IsLineFull(int row, int from, int to)
		{
			for (int i = from; i < to; i++)
				if (!_tilemap.HasTile(new(i, row)))
					return false;

			return true;
		}

		private void ShiftRow(int row, int shift, int from, int to)
		{
			if (shift == 0)
				return;

			for (int i = from; i < to; i++)
			{
				TileBase tile = _tilemap.GetTile(new(i, row));
				_tilemap.SetTile(new(i, row - shift), tile);
			}
		}
	}
}