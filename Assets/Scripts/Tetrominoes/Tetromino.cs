using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	[System.Serializable]
	public abstract class Tetromino
	{
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

		public abstract Tetromino Clone();

		public abstract Tetromino CloneWithTile(Tile tile);
	}
}
