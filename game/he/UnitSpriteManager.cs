using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace he
{
	public sealed class UnitSpriteManager
	{
#region Attributes
		//! Working path.
		private readonly string wrkPath;
#endregion
		
		//! Load sprite description.
		public UnitSpriteDescription Load(string Name)
		{
			string text = this.wrkPath + Name + "/data";
//			Object @object = Resources.Load(text, typeof(TextAsset));
			XmlReader xmlReader = XmlReader.Create(new StringReader(((TextAsset)Resources.Load(text, typeof(TextAsset))).text));
			xmlReader.Read();
			xmlReader.MoveToContent();
			if (!xmlReader.ReadToDescendant("type"))
			{
				throw new XmlException("Cannot find element 'type' - " + xmlReader.Name);
			}
			UnitSpriteDescription unitSpriteDescription = new UnitSpriteDescription();
			do
			{
				UnitSpriteTypeDescription value = new UnitSpriteTypeDescription(xmlReader.GetAttribute("sprite"));
				string attribute = xmlReader.GetAttribute("id");
				xmlReader.ReadToDescendant("animation");
				do
				{
					string attribute2 = xmlReader.GetAttribute("id");
					byte fps = Convert.ToByte(xmlReader.GetAttribute("fps"));
					UnitSpriteAnimationDescription unitSpriteAnimationDescription = new UnitSpriteAnimationDescription(attribute2, fps);
					xmlReader.ReadToDescendant("orientation");
					do
					{
						LookDirection direction = this.ConvertOrientation(xmlReader.GetAttribute("id"));
						UnitSpriteAnimationOrientationDescription unitSpriteAnimationOrientationDescription = new UnitSpriteAnimationOrientationDescription();
						unitSpriteAnimationDescription.Add(direction, unitSpriteAnimationOrientationDescription);
						xmlReader.ReadToDescendant("item");
						do
						{
							unitSpriteAnimationOrientationDescription.Add(new UnitSpriteAnimationFrameDescription(Convert.ToSingle(xmlReader.GetAttribute("woffset")), Convert.ToSingle(xmlReader.GetAttribute("hoffset")), Convert.ToSingle(xmlReader.GetAttribute("width")), Convert.ToSingle(xmlReader.GetAttribute("height"))));
						}
						while (xmlReader.ReadToNextSibling("item"));
					}
					while (xmlReader.ReadToNextSibling("orientation"));
				}
				while (xmlReader.ReadToNextSibling("animation"));
				unitSpriteDescription[attribute] = value;
			}
			while (xmlReader.ReadToNextSibling("type"));
			return unitSpriteDescription;
		}

		//! Convert orientation
		private LookDirection ConvertOrientation(string Str)
		{
			LookDirection result = LookDirection.NORTH;

			switch (Str)
			{
				case "south":
					result = LookDirection.SOUTH;
					break;
				case "north":
					result = LookDirection.NORTH;
					break;
				case "east":
					result = LookDirection.EAST;
					break;
				case "west":
					result = LookDirection.WEST;
					break;
				case "southeast":
					result = LookDirection.SOUTHEAST;
					break;
				case "southwest":
					result = LookDirection.SOUTHWEST;
					break;
				case "northeast":
					result = LookDirection.NORTHEAST;
					break;
				case "northwest":
					result = LookDirection.NORTHWEST;
					break;
			}

			return result;
		}

#region Construction
		public UnitSpriteManager(string WrkPath)
		{
			wrkPath = WrkPath;
		}
#endregion
	}
}
