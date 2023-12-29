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
	}
}
