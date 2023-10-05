using Godot;

namespace UnnamedGame.scripts;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Draw()
	{
		DrawRect(new Rect2(1.0f, 1.0f, 1920.0f, 1080.0f), Colors.DarkOliveGreen);
	}
}