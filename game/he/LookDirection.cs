﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		public static LookDirection Convert(Direction Dir)
		{
			LookDirection direction = LookDirection.EAST;

			switch(Dir)
			{
				case he.Direction.EAST:
					direction = LookDirection.EAST;
					break;
				case he.Direction.NORTH:
					direction = LookDirection.NORTH;
					break;
				case he.Direction.NORTH_EAST:
					direction = LookDirection.NORTHEAST;
					break;
				case he.Direction.NORTH_WEST:
					direction = LookDirection.NORTHWEST;
					break;
				case he.Direction.SOUTH:
					direction = LookDirection.SOUTH;
					break;
				case he.Direction.SOUTH_EAST:
					direction = LookDirection.SOUTHEAST;
					break;
				case he.Direction.SOUTH_WEST:
					direction = LookDirection.SOUTHWEST;
					break;
				case he.Direction.WEST:
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
