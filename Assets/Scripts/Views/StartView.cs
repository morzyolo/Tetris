using System;
using UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class StartView : MonoBehaviour
	{
		public event Action OnPlayButtonPressed;

		public int Seed => _inputField.Seed;

		[SerializeField] private Button _playButton;
		[SerializeField] private SeedInputField _inputField;

		public void Show() => SetActive(true);

		public void Hide() => SetActive(false);

		private void SetActive(bool isActive)
			=> gameObject.SetActive(isActive);

		private void NotifyPlay() => OnPlayButtonPressed?.Invoke();

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