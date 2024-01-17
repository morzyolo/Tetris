using DataHandlers;
using GameStateMachine;
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
			Container container = new();

			StateMachine stateMachine = new();

			Control control = new(_grid, container, stateMachine);
			InputHandler input = new(control, stateMachine);

			StartPresenter startPresenter = new(_startView, stateMachine);
			EndPresenter endPresenter = new(_endView, stateMachine);

			Switcher switcher = new(_grid, container, tetrominoFactory, startPresenter, stateMachine);

			_disposableList.Add(input);
			_disposableList.Add(control);
			_disposableList.Add(switcher);
			_disposableList.Add(startPresenter);
			_disposableList.Add(endPresenter);

			stateMachine.Init();
		}

		private void OnDisable()
		{
			foreach (var disposable in _disposableList)
				disposable.Dispose();
		}
	}
}
