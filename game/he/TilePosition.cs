using System;

namespace he
{
	public enum TileSector
	{
		NW,
		SW,
		NE,
		SE,
	}
	//! Tile accurate position.
	public sealed class TilePosition
	{
#region Attributes
		//! Tile.
		public TerrainTile tile;
		//! Sector within given tile.
		public TileSector sector;
#endregion

#region Construction
		public TilePosition(TerrainTile Tile, TileSector Sector)
		{
			tile = Tile;
			sector = Sector;
		}
#endregion
	}
} /*he*/
