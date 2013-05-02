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
	//! Selected mercenary.
	private GameObject soldierSelected;
	//! Terrain manager.
	private TerrainManager terrainManager;
	//! Path manager.
	private AStarPathManager pathManager;
	//! Path visualizer.
	private PathVisualizer pathVisualizer;
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
		// Create A* path manager and GO
		pathManager = PrefabManager.Create("AStartPathManager").GetComponent<AStarPathManager>();
		pathManager.transform.parent = transform;

		// Instantiate cursor if not found
		GameObject cursor_go;
		if ((cursor_go = GameObject.Find("Cursor")) == null)
		{
			var prefab_class = Resources.Load("Prefabs/Cursor", typeof(GameObject));
			cursor_go = (GameObject)Instantiate(prefab_class);
			cursor_go.name = prefab_class.name;
			// Save it
			cursor = cursor_go.GetComponent<GameCursor>();
		}
		// Instantiate hover
		if ((hover = GameObject.Find("Hover")) == null)
		{
			var prefab_class = Resources.Load("Prefabs/Hover", typeof(GameObject));
			hover = (GameObject)Instantiate(prefab_class);
			hover.name = prefab_class.name;
		}
		// Create path visulizer child GO and get main component
		var path_visualizer_go = PrefabManager.Create("PathVisualizer");
		path_visualizer_go.transform.parent = transform;
		pathVisualizer = path_visualizer_go.GetComponent<PathVisualizer>();
	}

	void Update()
	{
	}
#endregion
}
