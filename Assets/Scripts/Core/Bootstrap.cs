using DataHandlers;
using InputHandlers;
using TetrominoGridHandlers;
using TetrominoHandlers;
using Transformations;
using UnityEngine;

namespace Core
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private TetrominoGrid _grid;
		[SerializeField] private InputHandler _input;

		private Switcher _switcher;

		private void Awake()
		{
			TileLoader tileLoader = new();
			TetrominoRepository tetrominoRepository = new(tileLoader.LoadTiles(), new WallKickData());
			TetrominoFactory tetrominoFactory = new(tetrominoRepository);
			Container container = new(tetrominoFactory.Produce());
			HorizontalMover horizontalMover = new(_grid, container);
			Rotator rotator = new(_grid, container);
			Control control = new(horizontalMover, rotator);
			_input.Init(control);

			DownMover downMover = new(_grid, container);
			_switcher = new(container, tetrominoFactory, downMover);
		}

		private void OnDisable()
		{
			_switcher.Dispose();
		}
	}
}
