using UnityEngine;
using System.Collections;

namespace he.script
{
	public class UnitSoldierController : MonoBehaviour
	{
#region Fields
		//! Terrain manager.
//		private TerrainManager m_TerrainManager;
		//! Soldier.
		private UnitSoldier m_Soldier;
		//! Sprite.
		//	public Sprite sprite;
#endregion

#region Properties
		public UnitSoldier soldier { get { return m_Soldier; } set { m_Soldier = value; } }
#endregion

#region Operations
		void Start()
		{
			// Set position
//			transform.position = m_TerrainManager.GetPosition(m_Soldier.position.tile);
			// Update sprite position
			//		sprite.Transform();
		}
#endregion
	}
}