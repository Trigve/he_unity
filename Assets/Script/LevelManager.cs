using UnityEngine;
using System.Collections.Generic;

//! Main class for each level.
/*!
	In each scene one instance of this component must exist.It handles level
	specific stuff and is served as entry point.
*/
public class LevelManager : MonoBehaviourEx
{
#region Attributes
	//! Game cursor.
	private GameCursor cursor;
	//! Hover cursor.
	private GameObject hover;
	//! Terrain manager.
	private TerrainManager terrainManager;
	//! Path visualizer.
	private PathVisualizer pathVisualizer;
	//! Soldier manager.
	public SoldierManager soldierManager;
	//! Sprite manager.
	private SpriteManager spriteManager;
#endregion

#region Properies
	//! Get terrain manager/map.
	public TerrainManager terrain
	{
		get
		{
			return terrainManager;
		}
	}
#endregion

#region Operations
	void Awake()
	{
		terrainManager = GameObject.Find("Map").GetComponent<TerrainManager>();
		// Create sprite manager
		var sprite_manager_go = PrefabManager.Create("SpriteManager");
		sprite_manager_go.transform.parent = transform;
		spriteManager = sprite_manager_go.GetComponent<SpriteManager>();
		// Create soldier manager
		soldierManager = new SoldierManager("data/units/human/", terrainManager.map, spriteManager, terrainManager);
	}

	void Update()
	{
	}
#endregion
}
