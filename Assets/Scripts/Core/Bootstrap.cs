using DataHandlers;
using GameStates;
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
		[SerializeField] private EndView _endView;

		private readonly List<IDisposable> _disposableList = new();

		private void Awake()
		{
			TetrominoRepository tetrominoRepository = new(_tiles);
			TetrominoFactory tetrominoFactory = new(tetrominoRepository);
			Container container = new(tetrominoFactory.Produce());

			Switcher switcher = new(_grid, container, tetrominoFactory);
			GameState gameState = new(switcher);

			Control control = new(_grid, container, gameState);
			InputHandler input = new(control);

			StartPresenter startPresenter = new(_startView, control, switcher, input);
			EndPresenter endPresenter = new(_endView, switcher, input);

			_disposableList.Add(input);
			_disposableList.Add(switcher);
			_disposableList.Add(startPresenter);
			_disposableList.Add(endPresenter);
		}

		private void OnDisable()
		{
			foreach (var disposable in _disposableList)
				disposable.Dispose();
		}
	}
}
