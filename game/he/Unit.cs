using System;

namespace he
{
	//! Base class for all units.
	public abstract class Unit
	{
#region Fields
		//! Tiles which unit occupies.
		private TerrainTileHandle[] m_Position;
		//! Get the main tile of unit.
		private TerrainTileHandle m_Pivot;
#endregion
#region Properties
		//! Pivot position of unit.
		public TerrainTileHandle position
		{
			get
			{
				return m_Pivot;
			}
		}
#endregion

#region Construction
		protected Unit(TerrainTileHandle[] Positions, TerrainTileHandle Pivot)
		{
			m_Position = Positions;
			m_Pivot = Pivot;
		}

		protected Unit(TerrainTileHandle Position)
		{
			m_Position = new TerrainTileHandle[] { Position };
			m_Pivot = Position;
		}
#endregion
	}
} /*he*/
