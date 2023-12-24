using UnityEngine;

public class TetrominoGrid : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _tiledBorder;
	[SerializeField] private SpriteRenderer _leftBottomBorder;

	[SerializeField] private Vector2Int _gridSize = new(10, 18);
	[SerializeField] private int _spriteBorderSize = 1;

	private void Start()
	{
		ResizeGrid();
	}

	private void ResizeGrid()
	{
		_tiledBorder.size = _gridSize;

		float worldBorderSize = _spriteBorderSize / _leftBottomBorder.sprite.rect.size.x;
		Vector2 leftBottomGridSize = _gridSize;
		leftBottomGridSize.x += worldBorderSize;
		leftBottomGridSize.y += worldBorderSize;
		_leftBottomBorder.size = leftBottomGridSize;
		_leftBottomBorder.transform.localPosition = new Vector3(-worldBorderSize / 2, -worldBorderSize / 2);
	}
}
