using Godot;

public partial class Main : Node2D
{
	Player Player;
	GUI GUI;

	public override void _Ready()
	{
		Player = GetNode<Player>("%Player");
		GUI = GetNode<GUI>("%GUI");
		GUI.Player = Player;
	}
}
