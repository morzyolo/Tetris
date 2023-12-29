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
	}
}
