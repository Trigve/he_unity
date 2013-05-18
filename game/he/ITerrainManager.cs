using System;
using UnityEngine;

namespace he
{
	//! Terrain manager interface.
	public interface ITerrainManager
	{
#region Operations
		//! Get position of tile.
		Vector3 GetPosition(he.TerrainTile Tile);
#endregion
	}
} /*he*/
