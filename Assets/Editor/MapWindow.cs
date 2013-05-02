using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;

public class MapWindow : EditorWindow
{
	private int m_Width = 10;
	private int m_Height = 20;
	
	[MenuItem("Map/Create")]
	static void ShowWindow()
	{
		// Show only if map doesn't exist
		if(!GameObject.Find("Map"))
			EditorWindow.GetWindow(typeof(MapWindow));
	}

	// Use this for initialization
	void OnGUI ()
	{
		EditorGUILayout.PrefixLabel("Map Settings", EditorStyles.boldLabel);
		// Add Width, height controls
		m_Width = (int)EditorGUILayout.IntField("Width", m_Width);
		m_Height = (int)EditorGUILayout.IntField("Hieght", m_Height);
		
		if(GUILayout.Button("Create"))
		{
			// Create map GO
			GameObject map_go = new GameObject("Map");
			// Reset position
			map_go.transform.position.Set(0, 0, 0);
			// Add terrain component
			TerrainManager terrain_manager = map_go.AddComponent<TerrainManager>();
			// Create map
			var map = new he.Map(m_Width, m_Height, "summer");
			// Material manager
			var material_manager = new he.TerrainMaterialManager(Application.dataPath);
			he.TerrainTileSet tile_set = material_manager.GetTerrainSet(map.terrainName);
			// Load material
			var material = (Material)Resources.LoadAssetAtPath("Assets/Materials/" + tile_set.materialName + ".mat", typeof(Material));
			// Create terrain
			terrain_manager.CreateTerrain(map, tile_set, material);
		}
	}
}
