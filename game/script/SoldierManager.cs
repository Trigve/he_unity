using System;
using UnityEngine;


public sealed class SoldierManager
{
#region Attributes
	//! Map.
	private he.Map map;
	//! Unit sprite manager.
	private he.UnitSpriteManager unitSpriteManager;
	//! Sprite manager.
	private SpriteManager spriteManager;
	//! Terrain manger.
	private he.ITerrainManager terrainManager;
#endregion
#region Operations
	//! Create soldier controller.
	public GameObject create()
	{
		var soldier = new he.UnitSoldier(new he.TilePosition(map.GetTile(4, 5), he.TileSector.NW));
		// Load description
		var unit_sprite_desc = unitSpriteManager.Load("german/schutzen");
		// Create GO for unit
		var go = new GameObject();
		go.name = "soldier";
		// Add component
		var soldier_controller = go.AddComponent<UnitSoldierController>();
		soldier_controller.soldier = soldier;
		soldier_controller.terrainManager = terrainManager;
		// Create sprite
		soldier_controller.sprite = spriteManager.AddSprite(go, 1, 1, new Vector2(0, 0), new Vector2(0.125f, 1), Vector3.zero, false);

		return go;
	}
#endregion

#region Construction
	public SoldierManager(string WrkPath, he.Map Map_, SpriteManager SpriteManager_, he.ITerrainManager TerrainManager)
	{
		map = Map_;
		unitSpriteManager = new he.UnitSpriteManager(WrkPath);
		spriteManager = SpriteManager_;
		terrainManager = TerrainManager;
	}
#endregion
}
