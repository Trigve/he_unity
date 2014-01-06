using System;

namespace he
{
	//! Handle.
	[Serializable]
	public sealed class NonMoveableObjectHandle
	{
#region Fields
		//! ID.
		public string m_Id;
#endregion

#region Construction
		public NonMoveableObjectHandle(string Id)
		{
			m_Id = Id;
		}
#endregion
	}
}
