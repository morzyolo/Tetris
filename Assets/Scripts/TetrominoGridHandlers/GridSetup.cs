using UnityEngine;

namespace TetrominoGridHandlers
{
	public class GridSetup : MonoBehaviour
	{
		[Header("Border Setup")]
		[SerializeField] private int _spriteBorderSize = 1;
		[SerializeField] private Color _borderColor = Color.black;
		[SerializeField] private SpriteRenderer _tiledBorder;
		[SerializeField] private SpriteRenderer _leftBottomBorder;

		public void ResizeGrid(Vector2Int gridSize)
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

		private void OnValidate()
		{
			_tiledBorder.color = _borderColor;
			_leftBottomBorder.color = _borderColor;

			if (_spriteBorderSize < 1)
				_spriteBorderSize = 1;
		}
	}
}