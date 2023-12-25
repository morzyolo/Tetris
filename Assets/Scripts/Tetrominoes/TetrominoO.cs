﻿using UnityEngine;

namespace Tetrominoes
{
	public class TetrominoO : ITetromino
	{
		public Vector2Int[] Cells => _cells;
		private readonly Vector2Int[] _cells = { new(0, 1), new(1, 1), new(0, 0), new(1, 0) };
	}
}
