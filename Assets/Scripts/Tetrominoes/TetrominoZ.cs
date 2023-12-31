using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoZ : Tetromino
	{
		public TetrominoZ(WallKickData wallKickData)
			: this(null, wallKickData.DefaultWallKicks)
		{ }

		private TetrominoZ(Tile tile, Vector2Int[,] wallKicks)
			: base(
				new(
					nameof(TetrominoZ),
					tile,
					new Vector2Int[] { new(-1, 1), new(0, 1), new(0, 0), new(1, 0) },
					wallKicks))
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoZ(tile, Data.WallKicks);

		public override Tetromino Clone()
			=> new TetrominoZ(Data.Tile, Data.WallKicks);

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
