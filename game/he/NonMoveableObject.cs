﻿using System;
using System.Xml;
using UnityEngine;

namespace he
{
	//! Non moveable object.
	[Serializable]
	public sealed class NonMoveableObject
	{
#region Fields
		//! ID.
		private Guid m_Id;
#endregion

#region Save/Load
		//! Save xml.
		public void SaveXml(XmlWriter Writer)
		{
			Writer.WriteAttributeString("id", m_Id.ToString());
		}
#endregion
#region Operations
		//! Get handle.
		public NonMoveableObjectHandle GetHandle()
		{
			return new NonMoveableObjectHandle(m_Id.ToString());
		}

		//! Get id.
		public Guid id
		{
			get
			{
				return m_Id;
			}
		}
#endregion
#region Construction
		public NonMoveableObject(string Id)
		{
			m_Id = new System.Guid(Id);
		}

		public NonMoveableObject()
		{
			m_Id = Guid.NewGuid();
		}
#endregion
	}
} /*he*/
