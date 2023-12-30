using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	[System.Serializable]
	public abstract class Tetromino
	{
		public Vector2Int Position { get; set; }

		private const int _rotationCount = 4;

		public int RotationIndex
		{
			get => _rotationIndex;
			private set => _rotationIndex = (value + _rotationCount) % _rotationCount;
		}
		protected int _rotationIndex = 0;

		private readonly RotationMatrix _rotationMatrix = new();
		
		public string Name => _name;
		protected readonly string _name;

		public Tile Tile => _tile;
		protected readonly Tile _tile;

		public Vector2Int[] Cells => _cells;
		protected readonly Vector2Int[] _cells;

		protected Tetromino(string name, Tile tile, Vector2Int[] cells)
		{
			_name = name;
			_cells = cells;
			_tile = tile;
		}

		public abstract void Rotate(float direction);
		public abstract Tetromino Clone();
		public abstract Tetromino CloneWithTile(Tile tile);

		protected float GetRotationByRow(Vector2Int cell, int multiplier, int row)
			=> cell.x * multiplier * _rotationMatrix[row, 0]
				+ cell.y * multiplier * _rotationMatrix[row, 1];
	}
}
