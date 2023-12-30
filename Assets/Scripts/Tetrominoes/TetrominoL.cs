using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoL : Tetromino
	{
		public TetrominoL()
			: this(null)
		{ }

		public TetrominoL(Tile tile)
			: base(
				nameof(TetrominoL),
				tile,
				new Vector2Int[] { new(1, 1), new(-1, 0), new(0, 0), new(1, 0) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoL(tile);

		public override Tetromino Clone()
			=> new TetrominoL(_tile);

		public override void Rotate(float direction)
		{
			int multiplier = direction > 0 ? 1 : -1;

			for (int i = 0; i < _cells.Length; i++)
				_cells[i].Set(
					Mathf.RoundToInt(GetRotationByRow(_cells[i], multiplier, 0)),
					Mathf.RoundToInt(GetRotationByRow(_cells[i], multiplier, 1)));
		}
	}
}
