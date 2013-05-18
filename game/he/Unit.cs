using System;

namespace he
{
	//! Base class for all units.
	public abstract class Unit
	{
#region Attributes
		//! Position of unit.
		public TilePosition position { get; set; }
#endregion

#region Construction
		protected Unit(TilePosition Pos)
		{
			position = Pos;
		}
#endregion
	}
} /*he*/
