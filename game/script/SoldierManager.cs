using System;
using UnityEngine;

namespace he.script
{
	public sealed class SoldierManager : MonoBehaviourEx
	{
#region Attributes
		//! Map.
		private TerrainManager m_Map;
#endregion

#region Operations
		//! Create soldier controller.
		public GameObject create()
		{
			var soldier = new he.UnitSoldier(new he.TerrainTileHandle(5, 5, 0, 0));
			// Load description
			//		var unit_sprite_desc = unitSpriteManager.Load("german/schutzen");
			// Create GO for unit
			var go = new GameObject();
			go.name = "soldier";
			// Add component
			var soldier_controller = go.AddComponent<UnitSoldierController>();
			soldier_controller.soldier = soldier;
//			soldier_controller.terrainManager = terrainManager;
			// Create sprite
			//		soldier_controller.sprite = spriteManager.AddSprite(go, 1, 1, new Vector2(0, 0), new Vector2(0.125f, 1), Vector3.zero, false);

			return go;
		}
#endregion

#region Construction
		public SoldierManager(string WrkPath, TerrainManager Map_)
		{
			m_Map = Map_;
		}
		#endregion
	}
}