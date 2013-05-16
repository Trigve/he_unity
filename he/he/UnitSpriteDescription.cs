using System;
using System.Collections.Generic;

namespace he
{
	public sealed class UnitSpriteDescription
	{
#region Attributes
		//! Map of all types.
		Dictionary<string, UnitSpriteTypeDescription> types = new Dictionary<string, UnitSpriteTypeDescription>();
#endregion

#region Operations
		//! Add new type description.
		public UnitSpriteTypeDescription this[string Type_]
		{
			get
			{
				return types[Type_];
			}
			set
			{
				types[Type_] = value;
			}
		}
#endregion

#region Construction
#endregion
	}
} /*he*/
