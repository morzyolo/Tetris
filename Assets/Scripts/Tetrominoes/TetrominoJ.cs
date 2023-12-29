using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoJ : Tetromino
	{
		public TetrominoJ()
			: this(null)
		{ }

		public TetrominoJ(Tile tile)
			: base(
				nameof(TetrominoJ),
				tile,
				new Vector2Int[] { new(-1, 1), new(-1, 0), new(0, 0), new(1, 0) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoJ(tile);
	}
}
