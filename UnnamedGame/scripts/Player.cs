using Godot;

namespace UnnamedGame.scripts;

public partial class Player : CharacterBody2D
{
    [Export] private int _speed = 800;

    Vector2 _velocity;
    Vector2 _direction;

    private void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("player_move_left", "player_move_right", "player_move_up", "player_move_down");
        Velocity = inputDirection * _speed;
    }
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
    }
}