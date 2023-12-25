using System;
using System.Linq;
using Tetrominoes;

namespace TetrominoGridHandlers
{
	public class TetrominoFactory
	{
		private readonly Random _random;

		private readonly bool[] _isCreatedTetrominoes;
		private readonly Func<ITetromino>[] _tetrominoesFuncs =
		{
			() => new TetrominoI(),
			() => new TetrominoJ(),
			() => new TetrominoL(),
			() => new TetrominoO(),
			() => new TetrominoS(),
			() => new TetrominoT(),
			() => new TetrominoZ(),
		};

		public TetrominoFactory(int seed)
		{
			_random = new(seed);
			_isCreatedTetrominoes = new bool[_tetrominoesFuncs.Length];
		}

		public ITetromino Produce()
		{
			int tetrominoId = _random.Next(_tetrominoesFuncs.Length);

			if (_isCreatedTetrominoes[tetrominoId])
			{
				int falseCount = _isCreatedTetrominoes.Count(isCreated => !isCreated);

				if (falseCount == 0)
					Array.Fill(_isCreatedTetrominoes, false);
				else
					tetrominoId = GetIndexFromRemaining(tetrominoId % falseCount);
			}

			_isCreatedTetrominoes[tetrominoId] = true;
			return _tetrominoesFuncs[tetrominoId]();
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
