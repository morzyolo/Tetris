using Tetrominoes;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TetrominoGridHandlers
{
	public class TetrominoGrid : MonoBehaviour
	{
		[SerializeField] private Tilemap _tilemap;
		[SerializeField] private GridSetup _gridSetup;

		[Header("Grid stats")]
		[SerializeField] private Vector2Int _gridSize = new(10, 18);
		[SerializeField] private Vector2Int _spawnPosition = new(5, 16);


		private void Awake()
		{
			_gridSetup.ResizeGrid(_gridSize);
		}

		public void SpawnTetromino(Tetromino tetromino)
		{
			for (int i = 0; i < tetromino.Cells.Length; i++)
				_tilemap.SetTile(
					(Vector3Int)(tetromino.Cells[i] + _spawnPosition),
					tetromino.Tile);
		}
	}
}
