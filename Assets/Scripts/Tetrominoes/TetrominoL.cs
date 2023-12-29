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
	}
}
