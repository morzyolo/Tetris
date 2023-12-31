using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	[System.Serializable]
	public abstract class Tetromino
	{
		public Vector2Int Position { get; set; }

		public TetrominoData Data => _data;
		private readonly TetrominoData _data;

		protected Tetromino(TetrominoData data)
		{
			_data = data;
		}

		public abstract void Rotate(float direction);
		public abstract Tetromino Clone();
		public abstract Tetromino CloneWithTile(Tile tile);

		protected float GetRotationByRow(Vector2Int cell, int multiplier, int row)
			=> cell.x * multiplier * _data.Matrix[row, 0]
				+ cell.y * multiplier * _data.Matrix[row, 1];
	}
}
