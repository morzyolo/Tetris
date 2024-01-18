using System;

namespace Models
{
	public class Score
	{
		public event Action<int> OnValueChanged;

		public int CurrentScore => _currentScore;
		private int _currentScore = 0;

		public void AddScore(int score)
		{
			_currentScore += Math.Max(0, score);
			OnValueChanged?.Invoke(_currentScore);
		}

		public void Reset()
		{
			_currentScore = 0;
		}
	}
}