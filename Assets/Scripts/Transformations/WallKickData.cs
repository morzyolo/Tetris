using UnityEngine;

namespace Transformations
{
	public class WallKickData
	{
		public Vector2Int[,] DefaultWallKicks => _defaultWallKicks;
		private readonly Vector2Int[,] _defaultWallKicks =
		{
			{ new(0, 0), new(-1, 0), new(-1,  1), new(0, -2), new(-1, -2) },
			{ new(0, 0), new( 1, 0), new( 1, -1), new(0,  2), new( 1,  2) },
			{ new(0, 0), new( 1, 0), new( 1, -1), new(0,  2), new( 1,  2) },
			{ new(0, 0), new(-1, 0), new(-1,  1), new(0, -2), new(-1, -2) },
			{ new(0, 0), new( 1, 0), new( 1,  1), new(0, -2), new( 1, -2) },
			{ new(0, 0), new(-1, 0), new(-1, -1), new(0,  2), new(-1,  2) },
			{ new(0, 0), new(-1, 0), new(-1, -1), new(0,  2), new(-1,  2) },
			{ new(0, 0), new( 1, 0), new( 1,  1), new(0, -2), new( 1, -2) },
		};

		public Vector2Int[,] WallKicksI => _wallKicksI;
		private readonly Vector2Int[,] _wallKicksI =
		{
			{ new (0, 0), new (-2, 0), new ( 1, 0), new (-2,-1), new ( 1, 2) },
			{ new (0, 0), new ( 2, 0), new (-1, 0), new ( 2, 1), new (-1,-2) },
			{ new (0, 0), new (-1, 0), new ( 2, 0), new (-1, 2), new ( 2,-1) },
			{ new (0, 0), new ( 1, 0), new (-2, 0), new ( 1,-2), new (-2, 1) },
			{ new (0, 0), new ( 2, 0), new (-1, 0), new ( 2, 1), new (-1,-2) },
			{ new (0, 0), new (-2, 0), new ( 1, 0), new (-2,-1), new ( 1, 2) },
			{ new (0, 0), new ( 1, 0), new (-2, 0), new ( 1,-2), new (-2, 1) },
			{ new (0, 0), new (-1, 0), new ( 2, 0), new (-1, 2), new ( 2,-1) },
		};
	}
}
