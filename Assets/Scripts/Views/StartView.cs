using System;
using UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
	public class StartView : MonoBehaviour
	{
		public event Action<int> OnPlayButtonPressed;

		[SerializeField] private Button _playButton;
		[SerializeField] private SeedInputField _inputField;

		private void NotifyPlay() => OnPlayButtonPressed?.Invoke(_inputField.Seed);

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