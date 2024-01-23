using Configs;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace TetrominoHandlers
{
	public sealed class HorizontalMover : IDisposable
	{
		private readonly Mover _mover;
		private readonly Container _container;
		private readonly TetrominoMovementConfig _config;

		private CancellationTokenSource _cancellationSource;

		public HorizontalMover(Mover mover, Container container, TetrominoMovementConfig config)
		{
			_mover = mover;
			_container = container;
			_config = config;
		}

		public void Start(float direction)
		{
			_cancellationSource?.Dispose();
			_cancellationSource = new();
			Move(direction).Forget();
		}

		public void Stop()
		{
			_cancellationSource.Cancel();
		}

		public void Dispose()
		{
			_cancellationSource?.Cancel();
			_cancellationSource?.Dispose();
		}

		private async UniTaskVoid Move(float direction)
		{
			while (!_cancellationSource.IsCancellationRequested)
			{
				bool canMove = _mover.TryTranslateTetromino(
					direction < 0 ? Vector2Int.left : Vector2Int.right);

				if (canMove)
					_container.SetTimeToLock();

				await UniTask.Delay(
					TimeSpan.FromSeconds(_config.DelayBetweenHorizontalMove),
					cancellationToken: _cancellationSource.Token);
			}
		}
	}
}
