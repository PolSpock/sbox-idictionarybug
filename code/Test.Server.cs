using IDictionaryBug;
using Sandbox;
using System.Collections.Generic;

namespace IDictionaryBug
{
	public partial class Test : BaseNetworkable
	{
		public enum MyEnum
		{
			Key0,
			Key1,
			Key2,
		}

		[Net] public IDictionary<MyEnum, MyNetworkableObject> EnumsAndDatas { get; set; } = new Dictionary<MyEnum, MyNetworkableObject>();

	}
}
