using System;

namespace he
{
	//! Description of sprite animation frame.
	class UnitSpriteAnimationFrameDescription
	{
#region Attributes
		//! Wofsset.
		readonly float woffset;
		//! Hoffset.
		readonly float hoffset;
		//! Width.
		readonly float width;
		//! Height.
		readonly float height;
#endregion

#region Construction
		public UnitSpriteAnimationFrameDescription(float Woffset, float Hoffset, float Width, float Height)
		{
			woffset = Woffset;
			hoffset = Hoffset;
			width = Width;
			height = Height;
		}
#endregion
	}
} /*he*/
