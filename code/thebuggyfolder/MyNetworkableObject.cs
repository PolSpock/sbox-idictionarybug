using Sandbox;

// BUGGED
namespace IDictionaryBug.thebuggyfolder

// WORK
//namespace IDictionaryBug
{
	public partial class MyNetworkableObject : BaseNetworkable
	{
		[Net] public int Id { get; set; }
		[Net] public int Score { get; set; }
		[Net] public Color Color { get; set; }
	}
}
