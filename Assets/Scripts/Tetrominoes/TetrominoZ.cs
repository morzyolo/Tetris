using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoZ : Tetromino
	{
		public TetrominoZ()
			: this(null)
		{ }

		public TetrominoZ(Tile tile)
			: base(
				nameof(TetrominoZ),
				tile,
				new Vector2Int[] { new(-1, 1), new(0, 1), new(0, 0), new(1, 0) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoZ(tile);

		public override Tetromino Clone()
			=> new TetrominoZ(_tile);
	}
}
