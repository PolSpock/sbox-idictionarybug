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

		[Net, Change] public IDictionary<MyEnum, MyNetworkableObject> EnumsAndDatas { get; set; } = new Dictionary<MyEnum, MyNetworkableObject>();

		public void OnEnumsAndDatasChanged( IDictionary<MyEnum, MyNetworkableObject> oldValue, IDictionary<MyEnum, MyNetworkableObject> newValue )
		{
			Log.Info( $"{(Host.IsServer ? "Server:" : "Client:")} OnEnumsAndDatasChanged. I will never be call :(" );
			Log.Info( oldValue );
			Log.Info( "----" );
			Log.Info( newValue );

		}

	}
}
