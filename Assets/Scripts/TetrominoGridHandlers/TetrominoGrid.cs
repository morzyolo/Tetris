using UnityEngine;

namespace TetrominoGridHandlers
{
	public class TetrominoGrid : MonoBehaviour
	{
		[SerializeField] private GridSetup _gridSetup;

		[Header("Grid stats")]
		[SerializeField] private Vector2Int _gridSize = new(10, 18);

		private void Awake()
		{
			_gridSetup.ResizeGrid(_gridSize);
		}
	}
}
