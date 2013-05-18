using UnityEngine;
using System;

namespace he
{
	public enum LookDirection
	{
		EAST = 0,
		SOUTHEAST = 1,
		SOUTH = 2,
		SOUTHWEST = 3,
		WEST = 4,
		NORTHWEST = 5,
		NORTH = 6,
		NORTHEAST = 7,
	}

	public static class LookDirectionConverter
	{
#region Operations
		//! Convert Map.Direction to LookDirection.
		public static LookDirection Convert(Map.Direction Dir)
		{
			LookDirection direction = LookDirection.EAST;

			switch(Dir)
			{
				case he.Map.Direction.EAST:
					direction = LookDirection.EAST;
					break;
				case he.Map.Direction.NORTH:
					direction = LookDirection.NORTH;
					break;
				case he.Map.Direction.NORTH_EAST:
					direction = LookDirection.NORTHEAST;
					break;
				case he.Map.Direction.NORTH_WEST:
					direction = LookDirection.NORTHWEST;
					break;
				case he.Map.Direction.SOUTH:
					direction = LookDirection.SOUTH;
					break;
				case he.Map.Direction.SOUTH_EAST:
					direction = LookDirection.SOUTHEAST;
					break;
				case he.Map.Direction.SOUTH_WEST:
					direction = LookDirection.SOUTHWEST;
					break;
				case he.Map.Direction.WEST:
					direction = LookDirection.WEST;
					break;
			}

			return direction;
		}

		//! Get the direction and angle for given LookAts.
		/*!
			If bool is true, right direction is used. Otherwise left.
		*/
		public static Quaternion DirectionToRotation(LookDirection To)
		{
			return Quaternion.AngleAxis((byte)To * 45, Vector3.up);
		}
#endregion
	}
}
