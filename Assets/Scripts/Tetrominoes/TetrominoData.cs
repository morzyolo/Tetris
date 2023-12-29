using Attributes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tetrominoes
{
	[System.Serializable]
	public class TetrominoData
	{
		public string Name => _name;
		[SerializeField][ReadOnly] private string _name;
		[SerializeField] private Tile _tile;

		private readonly Tetromino _tetromino;

		public TetrominoData(Tetromino tetromino)
		{
			_name = tetromino.Name;
			_tetromino = tetromino;
		}

		public Tetromino GetTetromino()
			=> _tetromino.CloneWithTile(_tile);
	}
}
