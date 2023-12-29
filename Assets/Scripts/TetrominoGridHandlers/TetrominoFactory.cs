using Configs;
using System;
using System.Linq;
using Tetrominoes;

namespace TetrominoGridHandlers
{
	public class TetrominoFactory
	{
		private readonly TetrominoConfig _config;

		private readonly bool[] _isCreatedTetrominoes;

		public TetrominoFactory(TetrominoConfig config)
		{
			_config = config;
			_isCreatedTetrominoes = new bool[_config.Tetrominos.Count];
		}

		public void ChangeSeed(int seed)
			=> UnityEngine.Random.InitState(seed);

		public Tetromino Produce()
		{
			int tetrominoId = UnityEngine.Random.Range(0, _config.Tetrominos.Count);

			if (_isCreatedTetrominoes[tetrominoId])
			{
				int falseCount = _isCreatedTetrominoes.Count(isCreated => !isCreated);

				if (falseCount == 0)
					Array.Fill(_isCreatedTetrominoes, false);
				else
					tetrominoId = GetIndexFromRemaining(tetrominoId % falseCount);
			}

			_isCreatedTetrominoes[tetrominoId] = true;
			return _config.Tetrominos[tetrominoId].GetTetromino();
		}

		private int GetIndexFromRemaining(int remainingTetraminoCount)
		{
			int currentId = 0;
			while (_isCreatedTetrominoes[currentId] || remainingTetraminoCount != 0)
			{
				if (_isCreatedTetrominoes[currentId])
				{
					currentId++;
					continue;
				}

				if (remainingTetraminoCount == 0)
					break;

				remainingTetraminoCount--;
				currentId++;
			}

			return currentId;
		}
	}
}
