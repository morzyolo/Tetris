using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoJ : Tetromino
	{
		public TetrominoJ(WallKickData wallKickData)
			: this(null, wallKickData.DefaultWallKicks)
		{ }

		private TetrominoJ(Tile tile, Vector2Int[,] wallKicks)
			: base(
				new(
					nameof(TetrominoJ),
					tile,
					new Vector2Int[] { new(-1, 1), new(-1, 0), new(0, 0), new(1, 0) },
					wallKicks))
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoJ(tile, Data.WallKicks);

		public override Tetromino Clone()
			=> new TetrominoJ(Data.Tile, Data.WallKicks);

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
