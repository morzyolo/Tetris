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
		{
			int multiplier = direction > 0 ? 1 : -1;

			for (int i = 0; i < Data.Cells.Length; i++)
			{
				Vector2 cell = Data.Cells[i];

				cell.x -= 0.5f;
				cell.y -= 0.5f;
				Data.Cells[i].Set(
					Mathf.CeilToInt(GetRotationByRow(Data.Cells[i], multiplier, 0)),
					Mathf.CeilToInt(GetRotationByRow(Data.Cells[i], multiplier, 1)));
			}
		}
	}
}
