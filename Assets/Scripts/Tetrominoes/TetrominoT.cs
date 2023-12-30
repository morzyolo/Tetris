using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoT : Tetromino
	{
		public TetrominoT()
			: this(null)
		{ }

		public TetrominoT(Tile tile)
			: base(
				nameof(TetrominoT),
				tile,
				new Vector2Int[] { new(0, 1), new(-1, 0), new(0, 0), new(1, 0) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoT(tile);

		public override Tetromino Clone()
			=> new TetrominoT(_tile);

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
