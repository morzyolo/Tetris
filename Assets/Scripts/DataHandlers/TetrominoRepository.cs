using System;
using System.Collections.Generic;
using Tetrominoes;
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
			Tetromino[] defaultTetrominoes =
			{
				new TetrominoI(),
				new TetrominoJ(),
				new TetrominoL(),
				new TetrominoO(),
				new TetrominoS(),
				new TetrominoT(),
				new TetrominoZ()
			};

			foreach (var tetromino in defaultTetrominoes)
			{
				var tile = Array.Find(tiles, t => t.name == tetromino.Name);

				if (tile == null)
				{
					Debug.LogError($"Tile {tetromino.Name} not found");
					tile = tiles[0];
				}

				_tetrominoes.Add(tetromino.CloneWithTile(tile));
			}
		}
	}
}
