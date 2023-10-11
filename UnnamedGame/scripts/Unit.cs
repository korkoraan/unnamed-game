using Godot;

namespace UnnamedGame.scripts;

public partial class Unit : CharacterBody2D
{
	[Export] private int speed { get; set; } = 400;
	public bool isSelected;
	public Vector2 movementTarget;

	public override void _Ready()
	{
		movementTarget = Transform.Origin; 
		DisableOutline();
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Position.DirectionTo(movementTarget) * speed;
		if (Position.DistanceTo(movementTarget) > 10)
		{
			MoveAndSlide();
		}
	}

	public void EnableOutline()
	{
		GetNode<Sprite2D>("Outline").Visible = true;
	}
	
	public void DisableOutline()
	{
		GetNode<Sprite2D>("Outline").Visible = false;
	}
}