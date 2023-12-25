using UnityEngine;

namespace Tetrominoes
{
	public interface ITetromino
	{
		public Vector2Int[] Cells { get; }
	}
}
