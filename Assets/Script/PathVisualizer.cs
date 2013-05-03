using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class PathVisualizer : MonoBehaviourEx
{
#region Attributes
	//! Terrain manager.
	private TerrainManager terrainManager;
	//! Mesh filter.
	private MeshFilter meshFilter;
#endregion

#region Operations
	void Awake()
	{
		terrainManager = GameObject.Find("Map").GetComponent<TerrainManager>();
		meshFilter = GetComponent<MeshFilter>();
	}

	//! Create path visualization.
	public void CreatePath(he.TerrainTile[] Tiles)
	{
		// Mesh for path visualizer
		Mesh mesh = new Mesh();
		// Create arrays needed
		var vertices = new Vector3[(Tiles.Length - 1) * 4];
		var uv1 = new Vector2[vertices.Length];
		var triangles = new int[(vertices.Length / 4) * 2 * 3];
		// Vertex iterator
		int vertex_iterator = vertices.Length - 4;

		he.TerrainTile previous = null;
		// Actual vertex
		foreach (var tile in Tiles)
		{
			// Actual vertex
			int actual_vertex = vertex_iterator;
			// Not first tile
			if (previous != null)
			{
				// Get actual direction
				he.Map.Direction dir = he.Map.GetDirection(previous, tile);
				// Set vertices
				vertices[actual_vertex++] = new Vector3(terrainManager.GetPosition(tile, 0).x, 0, terrainManager.GetPosition(tile, 0).z);
				vertices[actual_vertex++] = new Vector3(terrainManager.GetPosition(tile, 1).x, 0, terrainManager.GetPosition(tile, 1).z);
				vertices[actual_vertex++] = new Vector3(terrainManager.GetPosition(tile, 2).x, 0, terrainManager.GetPosition(tile, 2).z);
				vertices[actual_vertex++] = new Vector3(terrainManager.GetPosition(tile, 3).x, 0, terrainManager.GetPosition(tile, 3).z);

				// Hardcoded for now, need to change
				float texel_step = 0.125f;
				byte rot = (byte)he.LookDirectionConverter.Convert(dir);

				uv1[actual_vertex - 4] = new Vector2(texel_step * rot + texel_step / 2, 1);
				uv1[actual_vertex - 3] = new Vector2(texel_step * rot, 0.5f);
				uv1[actual_vertex - 2] = new Vector2(texel_step * rot + texel_step / 2, 0);
				uv1[actual_vertex - 1] = new Vector2(texel_step * rot + texel_step, 0.5f);

				int triangle_index = (((actual_vertex / 4) - 1) * 3 * 2);

				triangles[triangle_index++] = actual_vertex - 4;
				triangles[triangle_index++] = actual_vertex - 1;
				triangles[triangle_index++] = actual_vertex - 3;

				triangles[triangle_index++] = actual_vertex - 3;
				triangles[triangle_index++] = actual_vertex - 1;
				triangles[triangle_index++] = actual_vertex - 2;
				// Go backwards
				vertex_iterator -= 4;
			}
			// Update previous tile
			previous = tile;
		}
		// Visualize path
		mesh.vertices = vertices;
		mesh.uv = uv1;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();

		meshFilter.sharedMesh = mesh;
		renderer.sharedMaterial = (Material)Resources.Load("Materials/Steps", typeof(Material));
	}
#endregion
}