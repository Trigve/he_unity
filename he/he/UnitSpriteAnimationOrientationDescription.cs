using System;
using System.Collections.Generic;

namespace he
{
	class UnitSpriteAnimationOrientationDescription
	{
#region Attributes
		//! Look direction for animation.
		public readonly LookDirection direction;
		//! Array of all frames.
		List<UnitSpriteAnimationFrameDescription> frames = new List<UnitSpriteAnimationFrameDescription>();
#endregion

#region Operations
		//! Add new frame.
		public void Add(UnitSpriteAnimationFrameDescription Frame)
		{
			frames.Add(Frame);
		}
#endregion
	}
} /*he*/
