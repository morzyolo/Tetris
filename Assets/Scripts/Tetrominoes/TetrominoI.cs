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
	}
}
