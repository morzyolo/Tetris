using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoI : Tetromino
	{
		public TetrominoI()
			: this(null)
		{ }

		public TetrominoI(Tile tile)
			: base(
				nameof(TetrominoI),
				tile,
				new Vector2Int[] { new(-1, 1), new(0, 1), new(1, 1), new(2, 1) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoI(tile);

		public override Tetromino Clone()
			=> new TetrominoI(_tile);

		public override void Rotate(float direction)
		{
			int multiplier = direction > 0 ? 1 : -1;

			for (int i = 0; i < _cells.Length; i++)
			{
				Vector2 cell = _cells[i];

				cell.x -= 0.5f;
				cell.y -= 0.5f;
				_cells[i].Set(
					Mathf.CeilToInt(GetRotationByRow(_cells[i], multiplier, 0)),
					Mathf.CeilToInt(GetRotationByRow(_cells[i], multiplier, 1)));
			}
		}
	}
}
