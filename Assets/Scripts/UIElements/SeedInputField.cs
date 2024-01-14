using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
	public class SeedInputField : MonoBehaviour
	{
		private const int _seedSize = 9;
		private const int _maxSeed = 999_999_999;

		public int Seed => int.Parse(_inputField.text);

		[SerializeField] private TMP_InputField _inputField;
		[SerializeField] private Button _randomSeedButton;

		private void Awake()
		{
			SetRandomSeed();
		}

		private void SetRandomSeed()
			=> SetStringSeed(Random.Range(0, _maxSeed + 1).ToString());

		private void ValidateInput(string text)
		{
			if (text.StartsWith('-'))
			{
				text = text[1..];
				_inputField.text = text;
			}
		}

		private void RedactText(string str)
			=> SetStringSeed(str);

		private void SetStringSeed(string seed)
		{
			if (seed.Length > _seedSize)
				seed = seed[.._seedSize];

			_inputField.text = seed.PadLeft(_seedSize, '0');
		}

		private void OnEnable()
		{
			_randomSeedButton.onClick.AddListener(SetRandomSeed);
			_inputField.onValueChanged.AddListener(ValidateInput);
			_inputField.onEndEdit.AddListener(RedactText);
		}

		private void OnDisable()
		{
			_randomSeedButton.onClick.RemoveListener(SetRandomSeed);
			_inputField.onValueChanged.RemoveListener(ValidateInput);
			_inputField.onEndEdit.RemoveListener(RedactText);
		}
	}
}
