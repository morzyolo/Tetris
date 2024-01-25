using UnityEngine;

namespace TetrominoGridHandlers
{
	public class GridSetup : MonoBehaviour
	{
		[Header("Border Setup")]
		[SerializeField] private int _spriteBorderSize = 1;
		[SerializeField] private Color _borderColor = Color.black;
		[SerializeField] private Color _limitLineColor = Color.red;

		[Header("Sprites")]
		[SerializeField] private SpriteRenderer _tiledBorder;
		[SerializeField] private SpriteRenderer _leftBottomBorder;
		[SerializeField] private SpriteRenderer _limitArea;

		public void Setup(Vector2Int gridSize, int limitHeight)
		{
			ResizeGrid(gridSize);
			ResizeLimitLine(gridSize, limitHeight);
		}

		private void ResizeGrid(Vector2Int gridSize)
		{
			_tiledBorder.size = gridSize;

			float worldBorderSize = _spriteBorderSize / _leftBottomBorder.sprite.rect.size.x;
			Vector2 leftBottomGridSize = gridSize;
			leftBottomGridSize.x += worldBorderSize;
			leftBottomGridSize.y += worldBorderSize;
			_leftBottomBorder.size = leftBottomGridSize;
			_leftBottomBorder.transform.localPosition = new Vector3(-worldBorderSize / 2, -worldBorderSize / 2);

			transform.position = new Vector3(gridSize.x / 2, gridSize.y / 2);
		}

		private void ResizeLimitLine(Vector2Int gridSize, int limitHeight)
		{
			float areaYSize = Mathf.Clamp(gridSize.y - limitHeight, 0, float.MaxValue);
			_limitArea.size = new(gridSize.x, areaYSize);

			Vector3 limitAreaPosition = new(
				(float)gridSize.x / 2,
				limitHeight + areaYSize / 2);
			_limitArea.transform.position = limitAreaPosition;
		}

		private void OnValidate()
		{
			_tiledBorder.color = _borderColor;
			_leftBottomBorder.color = _borderColor;
			_limitArea.color = _limitLineColor;

			if (_spriteBorderSize < 1)
				_spriteBorderSize = 1;
		}
	}
}
