using Sandbox;

namespace IDictionaryBug;

partial class Pawn : AnimatedEntity
{
	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/sbox_props/watermelon/watermelon.vmdl" );

		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );

		Rotation = Input.Rotation;
		EyeRotation = Rotation;

		var movement = new Vector3( Input.Forward, Input.Left, 0 ).Normal;

		Velocity = Rotation * movement;

		Velocity *= Input.Down( InputButton.Run ) ? 1000 : 200;


		MoveHelper helper = new MoveHelper( Position, Velocity );
		helper.Trace = helper.Trace.Size( 16 );
		if ( helper.TryMove( Time.Delta ) > 0 )
		{
			Position = helper.Position;
		}

		if ( IsServer && Input.Pressed( InputButton.PrimaryAttack ) )
		{
			var ragdoll = new ModelEntity();
			ragdoll.SetModel( "models/citizen/citizen.vmdl" );
			ragdoll.Position = EyePosition + EyeRotation.Forward * 40;
			ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
			ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
			ragdoll.PhysicsGroup.Velocity = EyeRotation.Forward * 1000;
		}

		if (IsClient)
		{
			//foreach ( var kv in Game.Instance.Test.EnumsAndDatas )
			//{
			//	Log.Info( kv.Key );
			//	Log.Info( kv.Value );
			//}
		}
	}

	public override void FrameSimulate( Client cl )
	{
		base.FrameSimulate( cl );

		Rotation = Input.Rotation;
		EyeRotation = Rotation;
	}
}
