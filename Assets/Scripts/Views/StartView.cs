using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class StartView : MonoBehaviour
	{
		public event Action OnPlayButtonPressed;

		[SerializeField] private Button _playButton;

		private void NotifyPlay() => OnPlayButtonPressed?.Invoke();

		public void Show() => SetActive(true);

		public void Hide() => SetActive(false);

		private void SetActive(bool isActive)
			=> gameObject.SetActive(isActive);

		private void OnEnable()
		{
			_playButton.onClick.AddListener(NotifyPlay);
		}

		private void OnDisable()
		{
			_playButton.onClick.RemoveListener(NotifyPlay);
		}
	}
}