using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoO : Tetromino
	{
		public TetrominoO(WallKickData wallKickData)
			: this(null, wallKickData.DefaultWallKicks)
		{ }

		private TetrominoO(Tile tile, Vector2Int[,] wallKicks)
			: base(
				new(
					nameof(TetrominoO),
					tile,
					new Vector2Int[] { new(0, 1), new(1, 1), new(0, 0), new(1, 0) },
					wallKicks))
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoO(tile, Data.WallKicks);

		public override Tetromino Clone()
			=> new TetrominoO(Data.Tile, Data.WallKicks);

		public override void Rotate(float direction)
		{ }
	}
}
