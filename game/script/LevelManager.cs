using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Linq;
using UnityEngine;

namespace he.script
{
	//! Main class for each level.
	/*!
		In each scene one instance of this component must exist.It handles level
		specific stuff and is served as entry point.
	*/
	public class LevelManager : MonoBehaviourEx
	{
#region Attributes
		//! Hover cursor.
		public GameObject hover;
		//! Selected mercenary.
//		private GameObject soldierSelected;
		//! Path manager.
		public AStarPathManager pathManager;
		//! Terrain manager.
		public TerrainManager m_TerrainManager;
		//! Soldier manager.
		public SoldierManager m_SoldierManager;
#endregion

#region Properies
		public TerrainManager terrainManager
		{
			get
			{
				return m_TerrainManager;
			}
		}
		
		public SoldierManager soldierManager
		{
			get
			{
				return m_SoldierManager;
			}
		}
#endregion

#region Interface
#endregion

#region Interface Editor
		//! Create all assets.
		public void CreateAssets(string Path, IEditor AssteDatabase)
		{
			m_TerrainManager.CreateAssets(Path, AssteDatabase);
		}
#endregion

#region Save/Load
		//! Save scene as xml.
		public void SaveSceneXml(XmlWriter Writer, IEditor AssetDatabase)
		{
			// Make the root tag
			Writer.WriteStartElement("level");

			// Serialize map
			m_TerrainManager.SaveXml(Writer, AssetDatabase);

			Writer.WriteEndElement();
		}

		//! Load xml.
		public void LoadXml(XmlReader Reader, IEditor AssetDatabase)
		{
			Reader.MoveToContent();

			m_TerrainManager.LoadXml(Reader, AssetDatabase);
		}

		//! Save scene.
		public void SaveScene(string Path, IEditor AssetDatabase)
		{
			// Testing for now
			var stream = new FileStream(Application.dataPath + "/Scenes/" + Path + "scene.bytes", FileMode.Create);
			var formatter = new BinaryFormatter();

			// Serialize map
			m_TerrainManager.Save(formatter, stream, AssetDatabase);

			stream.Flush();
			stream.Close();
		}
#endregion

#region Operations
#endregion

#region Messages
		protected void Awake()
		{
		}

		void Update()
		{
		}
#endregion
	}
} /*he.script*/