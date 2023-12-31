using System;

namespace Transformations
{
	public class RotationMatrix
	{
		private readonly float _cosHalfPi = MathF.Cos(MathF.PI / 2);
		private readonly float _sinHalfPi = MathF.Sin(MathF.PI / 2);
		private readonly float[,] _matrix;

		public float this[int i, int j] => _matrix[i, j];

		public RotationMatrix()
		{
			_matrix = new float[,]
			{
				{ _cosHalfPi,  _sinHalfPi },
				{ -_sinHalfPi,  _cosHalfPi }
			};
		}
	}
}
