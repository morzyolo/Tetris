using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	public class TetrominoData
	{
		private const int _rotationCount = 4;

		public int RotationIndex
		{
			get => _rotationIndex;
			set => _rotationIndex = value < 0 ?
				_rotationCount - (-value) % _rotationCount
				: value % _rotationCount;
		}
		private int _rotationIndex = 0;

		public RotationMatrix Matrix => _matrix;
		private readonly RotationMatrix _matrix = new();

		public string Name => _name;
		protected readonly string _name;

		public Tile Tile => _tile;
		protected readonly Tile _tile;

		public Vector2Int[] Cells => _cells;
		protected readonly Vector2Int[] _cells;

		public Vector2Int[,] WallKicks => _wallKicks;
		protected readonly Vector2Int[,] _wallKicks;

		public TetrominoData(string name, Tile tile, Vector2Int[] cells, Vector2Int[,] wallKicks)
		{
			_name = name;
			_tile = tile;
			_cells = cells;
			_wallKicks = wallKicks;
		}
	}
}
