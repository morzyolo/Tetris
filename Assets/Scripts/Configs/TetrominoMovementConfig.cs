using UnityEngine;

namespace Configs
{
	[CreateAssetMenu(
		fileName = "Configs/TetrominoMovement",
		menuName = "Configs/TetrominoMovement",
		order = 1)]
	public class TetrominoMovementConfig : ScriptableObject
	{
		public float DefaultMoveDelay => _defaultMoveDelay;
		public float TimeToLock => _timeToLock;

		public float DefaultMoveDelayMultiplier => _defaultMoveDelayMultiplier;
		public float AcceleratedDelayMultiplier => _acceleratedDelayMultiplier;

		[Header("Movement Values")]
		[SerializeField] private float _defaultMoveDelay = 0.45f;
		[SerializeField] private float _timeToLock = 0.1f;

		[Header("Multipliers")]
		[SerializeField] private float _defaultMoveDelayMultiplier = 1f;
		[SerializeField] private float _acceleratedDelayMultiplier = 0.2f;

		private void OnValidate()
		{
			if (_defaultMoveDelay < 0f)
				_defaultMoveDelay = 1f;

			if (_defaultMoveDelayMultiplier < 0f)
				_defaultMoveDelayMultiplier = 1f;

			if (_acceleratedDelayMultiplier < 0f)
				_acceleratedDelayMultiplier = 1f;
		}
	}
}