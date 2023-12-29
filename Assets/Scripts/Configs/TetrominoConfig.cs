using System.Collections.Generic;
using Tetrominoes;
using UnityEngine;

namespace Configs
{
	[CreateAssetMenu(fileName = "Configs/Tetromino", menuName = "Configs/Tetromino", order = 1)]
	public class TetrominoConfig : ScriptableObject
	{
		public IReadOnlyList<TetrominoData> Tetrominos => _tetrominoes;
		[SerializeField] private List<TetrominoData> _tetrominoes;

		private void Awake()
		{
			_tetrominoes = new()
			{
				new (new TetrominoI()),
				new (new TetrominoJ()),
				new (new TetrominoL()),
				new (new TetrominoO()),
				new (new TetrominoS()),
				new (new TetrominoT()),
				new (new TetrominoZ())
			};
		}
	}
}
