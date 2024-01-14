using DataHandlers;
using InputHandlers;
using Presenters;
using System;
using System.Collections.Generic;
using TetrominoGridHandlers;
using TetrominoHandlers;
using UnityEngine;
using UnityEngine.Tilemaps;
using Views;

namespace Core
{
	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private TetrominoGrid _grid;

		[SerializeField] private Tile[] _tiles;

		[SerializeField] private StartView _startView;


		private readonly List<IDisposable> _disposableList = new();

		private void Awake()
		{
			TetrominoRepository tetrominoRepository = new(_tiles);
			TetrominoFactory tetrominoFactory = new(tetrominoRepository);
			Container container = new(tetrominoFactory.Produce());

			Control control = new(_grid, container);
			InputHandler input = new(control);

			Switcher switcher = new(_grid, container, tetrominoFactory);

			StartPresenter startPresenter = new(_startView, control, switcher, input);

			_disposableList.Add(input);
			_disposableList.Add(switcher);
			_disposableList.Add(startPresenter);
		}

		private void OnDisable()
		{
			foreach (var disposable in _disposableList)
				disposable.Dispose();
		}
	}
}
