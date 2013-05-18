using UnityEngine;
using System.Collections;

public class UnitSoldierController : MonoBehaviour
{
#region Attributes
	//! Terrain manager.
	public he.ITerrainManager terrainManager;
	//! Soldier.
	public he.UnitSoldier soldier;
	//! Sprite.
	public Sprite sprite;
#endregion

#region Operations
	void Start()
	{
		// Set position
		transform.position = terrainManager.GetPosition(soldier.position.tile);
		// Update sprite position
		sprite.Transform();
	}
#endregion
}
