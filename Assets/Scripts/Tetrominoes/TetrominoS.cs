using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoS : Tetromino
	{
		public TetrominoS(WallKickData wallKickData)
			: this(null, wallKickData.DefaultWallKicks)
		{ }

		private TetrominoS(Tile tile, Vector2Int[,] wallKicks)
			: base(
				new(
					nameof(TetrominoS),
					tile,
					new Vector2Int[] { new(-1, 1), new(0, 1), new(1, 1), new(2, 1) },
					wallKicks))
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoS(tile, Data.WallKicks);

		public override Tetromino Clone()
			=> new TetrominoS(Data.Tile, Data.WallKicks);

		public override void Rotate(float direction)
		{
			int multiplier = direction > 0 ? 1 : -1;

			for (int i = 0; i < Data.Cells.Length; i++)
				Data.Cells[i].Set(
					Mathf.RoundToInt(GetRotationByRow(Data.Cells[i], multiplier, 0)),
					Mathf.RoundToInt(GetRotationByRow(Data.Cells[i], multiplier, 1)));
		}
	}
}
