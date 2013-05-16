using System;
using UnityEngine;

namespace he
{
	public sealed class SoldierManager
	{
#region Attributes
		//! Map.
		private Map map;
		//! Unit sprite manager.
		private UnitSpriteManager unitSpriteManager;
		//! Sprite manager.
		private ISpriteManager spriteManager;
#endregion
#region Operations
		//! Create soldier controller.
		public GameObject create()
		{
			var soldier = new he.UnitSoldier(new he.TilePosition(map.GetTile(10, 5), he.TileSector.NW));
			// Load description
			var unit_sprite_desc = unitSpriteManager.Load("german/schutzen");
			// Create GO for unit
			var go = new GameObject();
			go.name = "soldier";
			// Create sprite
//			spriteManager.AddSprite(go, 1, 1, new Vector2(0, 0), new Vector2(0.125f, 0.125f), Vector3.zero, false);

			return go;
		}
#endregion

#region Construction
		public SoldierManager(string WrkPath, Map Map_, ISpriteManager SpriteManager_)
		{
			map = Map_;
			unitSpriteManager = new UnitSpriteManager(WrkPath);
			spriteManager = SpriteManager_;
		}
#endregion
	}
} /*he*/

