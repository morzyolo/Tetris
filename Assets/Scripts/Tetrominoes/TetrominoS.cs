using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoS : Tetromino
	{
		public TetrominoS()
			: this(null)
		{ }

		public TetrominoS(Tile tile)
			: base(
				nameof(TetrominoS),
				tile,
				new Vector2Int[] { new(-1, 1), new(0, 1), new(1, 1), new(2, 1) })
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoS(tile);
	}
}
