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
				nameof(TetrominoS),
				tile,
				new Vector2Int[] { new(-1, 1), new(0, 1), new(1, 1), new(2, 1) },
				wallKicks)
		{ }

		public override Tetromino CloneWithTile(Tile tile)
			=> new TetrominoS(tile, _wallKicks);

		public override Tetromino Clone()
			=> new TetrominoS(_tile, _wallKicks);

		public override void Rotate(float direction)
		{
			int multiplier = direction > 0 ? 1 : -1;

			for (int i = 0; i < _cells.Length; i++)
				_cells[i].Set(
					Mathf.RoundToInt(GetRotationByRow(_cells[i], multiplier, 0)),
					Mathf.RoundToInt(GetRotationByRow(_cells[i], multiplier, 1)));
		}
	}
}
