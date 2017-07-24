using System;
using System.Collections;

namespace YMK.FrameWork.Infrastructure
{
	public class IdentityMap
	{
		#region?Fields?(1)?

		private readonly Hashtable mappedTypes;

		#endregion?Fields?

		#region?Enums?(1)?

		private enum ObjectState
		{
			Created,
			Deleted,
			Updated
		}

		#endregion?Enums?

		#region?Constructors?(1)?

		public IdentityMap()
		{
			this.mappedTypes = new Hashtable();
		}

		#endregion?Constructors?

		#region?Methods?(4)?

		public object GetObject(Type objectType, object key)
		{
			Hashtable map = this.GetMapFromType(objectType);
			object item = map[key.ToString()];
			return item;
		}

		public void PutObject(object item, object key)
		{
			Type objectType = item.GetType();
			Hashtable map = this.GetMapFromType(objectType);
			map[key.ToString()] = item;
		}

		private Hashtable GetMap(string mapName)
		{
			var map = (Hashtable) this.mappedTypes[mapName];
			if (map == null)
			{
				var newMap = new Hashtable();
				this.mappedTypes[mapName] = newMap;
				map = newMap;
			}
			return map;
		}

		private Hashtable GetMapFromType(Type objectType)
		{
			string typeName = objectType.FullName;
			Hashtable map = this.GetMap(typeName);
			return map;
		}

		#endregion?Methods?

		#region?Nested?Classes?(1)?

		private class MappedItem
		{
			#region?Properties?(2)?

			public object Item { get; set; }

			public ObjectState State { get; set; }

			#endregion?Properties?
		}

		#endregion?Nested?Classes?
	}
}


