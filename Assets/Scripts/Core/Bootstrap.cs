using DataHandlers;
using InputHandlers;
using TetrominoGridHandlers;
using TetrominoHandlers;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private TetrominoGrid _grid;
		[SerializeField] private InputHandler _input;

		[SerializeField] private Tile[] _tiles;

		private Switcher _switcher;

		private void Awake()
		{
			TetrominoRepository tetrominoRepository = new(_tiles);
			TetrominoFactory tetrominoFactory = new(tetrominoRepository);
			Container container = new(tetrominoFactory.Produce());

			Control control = new(_grid, container);
			_input.Init(control);

			_switcher = new(_grid, container, tetrominoFactory);
			_switcher.SpawnTetromino();

			_ = control.StartMove();
		}

		private void OnDisable()
		{
			_switcher.Dispose();
		}
	}
}
