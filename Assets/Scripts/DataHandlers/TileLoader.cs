using UnityEngine;
using UnityEngine.Tilemaps;

namespace DataHandlers
{
	public class TileLoader
	{
		private readonly string _tilesPath = "Tiles";

		public Tile[] LoadTiles()
			=> Resources.LoadAll<Tile>(_tilesPath);
	}
}
