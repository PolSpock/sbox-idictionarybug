using IDictionaryBug;
using Sandbox;
using System;
using System.Linq;

namespace IDictionaryBug;

/// <summary>
public partial class Game : Sandbox.Game
{
	public static Game Instance
	{
		get => Sandbox.Game.Current as Game;
	}

	[Net] public Test Test { get; private set; }


	public Game()
	{
		if ( IsServer )
		{
			Log.Info( "My Gamemode Has Created Serverside!" );

			Test = new Test();

			var value1 = new MyNetworkableObject();
			value1.Id = 0;
			value1.Score = 1;
			value1.Color = Color.Red.ToString();

			Test.EnumsAndDatas.Add( Test.MyEnum.Key0, value1 );

			var value2 = new MyNetworkableObject();
			value2.Id = 1;
			value2.Score = 2;
			value2.Color = Color.Blue.ToString();

			Test.EnumsAndDatas.Add( Test.MyEnum.Key1, value2 );

			var value3 = new MyNetworkableObject();
			value3.Id = 2;
			value3.Score = 3;
			value3.Color = Color.Green.ToString();

			Test.EnumsAndDatas.Add( Test.MyEnum.Key2, value3 );

			Log.Info( Test.EnumsAndDatas );
		}
	}

	public override void ClientJoined( Client client )
	{
		base.ClientJoined( client );

		var pawn = new Pawn();
		client.Pawn = pawn;

		var spawnpoints = Entity.All.OfType<SpawnPoint>();

		var randomSpawnPoint = spawnpoints.OrderBy( x => Guid.NewGuid() ).FirstOrDefault();

		if ( randomSpawnPoint != null )
		{
			var tx = randomSpawnPoint.Transform;
			tx.Position = tx.Position + Vector3.Up * 50.0f; // raise it up
			pawn.Transform = tx;
		}
	}
}
