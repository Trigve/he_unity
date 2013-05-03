using UnityEngine;
using System.Collections.Generic;
using System;

public class AStarPathManager : MonoBehaviourEx
{
#region Attributes
	private TerrainManager terrainManager;
	//! Actual task.
	utils.Task actualTask;
	//! Last created path.
	/*!
		This object is also gizmo-drawed. Do not mix debug functions or bad
		things will happen.
	*/
	private he.AStarPathMap lastPath;
#if UNITY_EDITOR
	//! Time to sleep when drawing.
	public float time = 0.2f;
	
#endif
#endregion

#region Operations
	
	void Awake()
	{
		terrainManager = GameObject.Find("Map").GetComponent<TerrainManager>();
	}

	//! Create A* path.
	public he.TerrainTile[] CreatePath(TerrainManager TerrainManager_, he.TerrainTile From, he.TerrainTile To)
	{
		lastPath = new he.AStarPathMap(TerrainManager_, From, To);
		while (lastPath.RunOnce() == he.AStarPathMap.State.WAIT)
			;

		return lastPath.Path();

	}

#if UNITY_EDITOR
	public void CreatePathDebug(TerrainManager TerrainManager_, he.TerrainTile From, he.TerrainTile To)
	{
		if (actualTask != null)
			actualTask.Stop();

		actualTask = new utils.Task(CreatePathDebug_CoRo(TerrainManager_, From, To));
	}

	public System.Collections.IEnumerator CreatePathDebug_CoRo(TerrainManager TerrainManager_, he.TerrainTile From, he.TerrainTile To)
	{
		lastPath = new he.AStarPathMap(TerrainManager_, From, To);
		he.AStarPathMap.State state;
		do 
		{
			yield return new WaitForSeconds(time);
			state = lastPath.RunOnce();
		} while (state == he.AStarPathMap.State.WAIT);
	}
#endif

	void OnDrawGizmosSelected()
	{
		if (lastPath != null)
		{
			Gizmos.color = new Color(1, 1, 1);
			foreach (var tile in lastPath.ClosedSet())
			{
				Vector3 tile_from = terrainManager.GetPosition(tile);
				tile_from.y = 0.1f;

				Gizmos.DrawCube(tile_from, new Vector3(0.5f, 0.5f, 0.5f));
			}
			foreach (var node in lastPath.OpenSet())
			{
				Gizmos.color = new Color(node._1 / lastPath.f_x_End, lastPath.f_x_End / node._1, 0);

				Vector3 tile_from = terrainManager.GetPosition(node._2);
				tile_from.y = 0.1f;

				Gizmos.DrawCube(tile_from, new Vector3(0.1f, 0.1f, 0.1f));
			}
			{
				Gizmos.color = new Color(0, 1, 0);
				Vector3 tile_from = terrainManager.GetPosition(lastPath.end);
				tile_from.y = 0.1f;
				Gizmos.DrawCube(tile_from, new Vector3(0.3f, 0.3f, 0.3f));
			}
		}
		
		
	}
#endregion
}