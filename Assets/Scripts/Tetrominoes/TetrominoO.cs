using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoO : Tetromino
	{
		public TetrominoO()
			: this(null)
		{ }

		public TetrominoO(Tile tile)
			: base(
				nameof(TetrominoO),
				tile,
				new Vector2Int[] { new(0, 1), new(1, 1), new(0, 0), new(1, 0) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoO(tile);

		public override Tetromino Clone()
			=> new TetrominoO(_tile);

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
