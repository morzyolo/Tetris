using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class EndView : MonoBehaviour
	{
		public event Action OnRestartButtonPressed;

		[SerializeField] private ScoreView _scoreView;
		[SerializeField] private Button _restartButton;

		public void SetScore(int score)
			=> _scoreView.UpdateScore(score);

		public void Show() => SetActive(true);

		public void Hide() => SetActive(false);

		private void SetActive(bool isActive)
			=> gameObject.SetActive(isActive);

		private void NotifyRestart() => OnRestartButtonPressed?.Invoke();

		private void OnEnable()
		{
			_restartButton.onClick.AddListener(NotifyRestart);
		}

		private void OnDisable()
		{
			_restartButton.onClick.RemoveListener(NotifyRestart);
		}
	}
}