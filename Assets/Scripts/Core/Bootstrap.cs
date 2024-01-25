using Changers;
using Configs;
using Controllers;
using DataHandlers;
using GameStateMachine;
using InputHandlers;
using Models;
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
		[SerializeField] private TetrominoMovementConfig _tetrominoMovementConfig;

		[SerializeField] private TetrominoGrid _grid;

		[SerializeField] private Tile[] _tiles;

		[SerializeField] private StartView _startView;
		[SerializeField] private ScoreView _scoreView;
		[SerializeField] private EndView _endView;

		private readonly List<IDisposable> _disposableList = new();

		private void Awake()
		{
			TetrominoRepository tetrominoRepository = new(_tiles);
			TetrominoFactory tetrominoFactory = new(tetrominoRepository);
			Container container = new(_tetrominoMovementConfig);

			StateMachine stateMachine = new();

			_grid.Init();
			Control control = new(_grid, container, stateMachine, _tetrominoMovementConfig);
			InputHandler input = new(control, stateMachine);

			Score score = new();
			ScoreChanger scoreChanger = new(_grid, container, score);

			StartPresenter startPresenter = new(_startView, stateMachine);
			ScoreController scoreController = new(_scoreView, score, stateMachine);
			EndPresenter endPresenter = new(_endView, score, _grid, stateMachine);

			Spawner spawner = new(_grid);
			Switcher switcher = new(spawner, _grid, container, tetrominoFactory, startPresenter, stateMachine);

			_disposableList.Add(input);
			_disposableList.Add(control);
			_disposableList.Add(switcher);
			_disposableList.Add(scoreChanger);
			_disposableList.Add(startPresenter);
			_disposableList.Add(scoreController);
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
