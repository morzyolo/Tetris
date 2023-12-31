using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoI : Tetromino
	{
		public TetrominoI(WallKickData wallKickData)
			: this(null, wallKickData.WallKicksI)
		{ }

		private TetrominoI(Tile tile, Vector2Int[,] wallKicks)
			: base(
				new TetrominoData(
					nameof(TetrominoI),
					tile,
					new Vector2Int[] { new(-1, 1), new(0, 1), new(1, 1), new(2, 1) },
					wallKicks))
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoI(tile, Data.WallKicks);

		public override Tetromino Clone()
			=> new TetrominoI(Data.Tile, Data.WallKicks);

		public override void Rotate(float direction)
		{
			int multiplier = direction > 0 ? 1 : -1;

			for (int i = 0; i < Data.Cells.Length; i++)
			{
				Vector2 cell = Data.Cells[i];
				cell.x -= 0.5f;
				cell.y -= 0.5f;
				Data.Cells[i].Set(
					Mathf.CeilToInt(GetRotationByRow(cell, multiplier, 0)),
					Mathf.CeilToInt(GetRotationByRow(cell, multiplier, 1)));
			}
		}
	}
}
