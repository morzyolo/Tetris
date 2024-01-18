using TMPro;
using UnityEngine;

namespace Views
{
	public class ScoreView : MonoBehaviour
	{
		private const int _maxScoreSize = 9;

		[SerializeField] private TMP_Text _score;

		public void UpdateScore(int score)
		{
			string scoreText = score.ToString();
			_score.text = scoreText.PadLeft(_maxScoreSize, '0');
		}

		public void Show() => SetActive(true);

		public void Hide() => SetActive(false);

		private void SetActive(bool isActive)
			=> gameObject.SetActive(isActive);
	}
}