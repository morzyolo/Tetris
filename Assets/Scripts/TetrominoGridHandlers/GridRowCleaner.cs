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

		public void ClearRows(int minRow, int maxRow)
		{
			if (minRow > maxRow)
				return;

			RectInt gridBoundary = _grid.GridBoundary;
			int rowShift = 0;

			CheckRows(minRow, maxRow, gridBoundary, ref rowShift);

			if (rowShift > 0)
			{
				ShiftRows(maxRow + 1, gridBoundary.yMax - 1, rowShift, gridBoundary);

				for (int y = gridBoundary.yMax - rowShift; y < gridBoundary.yMax; y++)
					for (int x = gridBoundary.xMin; x < gridBoundary.xMax; x++)
						_tilemap.SetTile(new(x, y), null);
			}
		}

		private void CheckRows(int from, int to, RectInt boundary, ref int rowShift)
		{
			int row = from;

			while (row <= to)
			{
				if (IsLineFull(row, boundary))
					rowShift++;
				else
					ShiftRows(row, row, rowShift, boundary);

				row++;
			}
		}

		private bool IsLineFull(int row, RectInt boundary)
		{
			for (int x = boundary.xMin; x < boundary.xMax; x++)
				if (!_tilemap.HasTile(new(x, row)))
					return false;

			return true;
		}

		private void ShiftRows(int from, int to, int rowShift, RectInt boundary)
		{
			if (rowShift == 0)
				return;

			int row = from;

			while (row <= to)
			{
				for (int x = boundary.xMin; x < boundary.xMax; x++)
				{
					TileBase tile = _tilemap.GetTile(new(x, row));
					_tilemap.SetTile(new(x, row - rowShift), tile);
				}

				row++;
			}
		}
	}
}
