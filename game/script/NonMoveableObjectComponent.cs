﻿using System;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using UnityEngine;

namespace he.script
{
	//! Component for non moveable object
	[Serializable]
	public class NonMoveableObjectComponent : MonoBehaviourEx
	{
#region Fields
		//! Terrain partition.
		[SerializeField]
		private TerrainPartition m_Parent;
		//! Instance of non-moveable.
		private he.NonMoveableObject m_Instance;
#endregion

#region Properties

		public he.NonMoveableObject nonMoveable
		{
			get
			{
				return m_Instance;
			}
		}

		//! Set parent.
		public TerrainPartition parent
		{
			get
			{
				return m_Parent;
			}
			set
			{
				m_Parent = value;
			}
		}
#endregion

#region Save/Load
		//! Save xml.
		public void SaveXml(XmlWriter Writer, IEditor AssetDatabase)
		{
			// Write original prefab
			Writer.WriteAttributeString("prefab", AssetDatabase.GetAssetPath(AssetDatabase.GetPrefabParent(gameObject)));
			// Save instance
			m_Instance.SaveXml(Writer);
		}

		//! Load xml.
		public void LoadXml(XmlReader Reader, IEditor AssetDatabase)
		{
			m_Instance = new NonMoveableObject(Reader.GetAttribute("id"));
		}

		public void Save(IFormatter Formatter, Stream Stream_)
		{
			Formatter.Serialize(Stream_, m_Instance);
		}

		public void Load(IFormatter Formatter, Stream Stream_)
		{
			m_Instance = (NonMoveableObject)Formatter.Deserialize(Stream_);
		}
#endregion

#region Messages
#endregion

#region Construction
		public void This()
		{
			m_Instance = new he.NonMoveableObject();
		}
#endregion
	}
} /*j2.script*/
