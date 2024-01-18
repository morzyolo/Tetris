using DataHandlers;
using System;
using System.Linq;
using Tetrominoes;

namespace TetrominoGridHandlers
{
	public class TetrominoFactory
	{
		private readonly TetrominoRepository _repository;

		private readonly bool[] _isCreatedTetrominoes;

		public TetrominoFactory(TetrominoRepository repository)
		{
			_repository = repository;
			_isCreatedTetrominoes = new bool[_repository.Tetrominoes.Count];
		}

		public void ChangeSeed(int seed)
			=> UnityEngine.Random.InitState(seed);

		public Tetromino Produce()
		{
			int tetrominoId = UnityEngine.Random.Range(0, _repository.Tetrominoes.Count);

			if (_isCreatedTetrominoes[tetrominoId])
			{
				int falseCount = _isCreatedTetrominoes.Count(isCreated => !isCreated);

				if (falseCount == 0)
					Array.Fill(_isCreatedTetrominoes, false);
				else
					tetrominoId = GetIndexFromRemaining(tetrominoId % falseCount);
			}

			_isCreatedTetrominoes[tetrominoId] = true;
			return _repository.Tetrominoes[tetrominoId].Clone();
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
