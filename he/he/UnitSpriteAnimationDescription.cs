using System;
using System.Collections.Generic;

namespace he
{
	//! Sprite animation description.
	class UnitSpriteAnimationDescription
	{
#region Attributes
		//! Animation name.
		private readonly string name;
		//! FPS.
		private byte fps;
		//! Animation orientations.
		private Dictionary<LookDirection, UnitSpriteAnimationOrientationDescription> orienatations = new Dictionary<LookDirection, UnitSpriteAnimationOrientationDescription>();
#endregion

#region Operations
		//! Add new orientation.
		public void Add(LookDirection Direction, UnitSpriteAnimationOrientationDescription AnimationDesc)
		{
			orienatations[Direction] = AnimationDesc;
		}
#endregion

#region Construction
		public UnitSpriteAnimationDescription(string Name, byte Fps)
		{
			name = Name;
			fps = Fps;
		}
#endregion
	}
} /*he*/
