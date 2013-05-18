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
		TerrainTile tile;
		//! Sector within given tile.
		TileSector sector;
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
