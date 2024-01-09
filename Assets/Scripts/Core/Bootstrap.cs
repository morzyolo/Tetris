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
			HorizontalMover horizontalMover = new(_grid, container);
			Rotator rotator = new(_grid, container);
			Control control = new(horizontalMover, rotator);
			_input.Init(control);

			DownMover downMover = new(_grid, container);
			_switcher = new(_grid, container, tetrominoFactory);

			_grid.SpawnTetromino(container.CurrentTetromino);
			_ = downMover.Move();
		}

		private void OnDisable()
		{
			_switcher.Dispose();
		}
	}
}
