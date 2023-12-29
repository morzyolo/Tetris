using Configs;
using InputHandlers;
using TetrominoGridHandlers;
using TetrominoHandlers;
using UnityEngine;

namespace Core
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private TetrominoConfig _config;

		[SerializeField] private TetrominoGrid _grid;
		[SerializeField] private InputHandler _input;

		private Switcher _switcher;

		private void Awake()
		{
			TetrominoFactory tetrominoFactory = new(_config);
			Container container = new(tetrominoFactory.Produce());
			HorizontalMover horizontalMover = new(_grid, container);
			Rotator rotator = new(_grid, container);
			Control control = new(horizontalMover, rotator);
			_input.Init(control);

			DownMover downMover = new(_grid, container);
			_switcher = new(tetrominoFactory, downMover);
		}

		private void OnDisable()
		{
			_switcher.Dispose();
		}
	}
}
