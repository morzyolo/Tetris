using System;
using System.Collections.Generic;
using Tetrominoes;
using Transformations;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DataHandlers
{
	public class TetrominoRepository
	{
		public IReadOnlyList<Tetromino> Tetrominoes => _tetrominoes;
		private readonly List<Tetromino> _tetrominoes = new();

		public TetrominoRepository(Tile[] tiles)
		{
			InitTetrominoes(tiles);
		}

		private void InitTetrominoes(Tile[] tiles)
		{
			WallKickData wallKickData = new();
			Tetromino[] defaultTetrominoes =
			{
				new TetrominoI(wallKickData),
				new TetrominoJ(wallKickData),
				new TetrominoL(wallKickData),
				new TetrominoO(wallKickData),
				new TetrominoS(wallKickData),
				new TetrominoT(wallKickData),
				new TetrominoZ(wallKickData)
			};

			foreach (var tetromino in defaultTetrominoes)
			{
				var tile = Array.Find(tiles, t => t.name == tetromino.Data.Name);

				if (tile == null)
				{
					Debug.LogError($"Tile {tetromino.Data.Name} not found");
					tile = tiles[0];
				}

				_tetrominoes.Add(tetromino.CloneWithTile(tile));
			}
		}
	}
}
