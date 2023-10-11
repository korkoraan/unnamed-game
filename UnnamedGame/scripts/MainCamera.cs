using Godot;

namespace UnnamedGame.scripts;

public partial class MainCamera : Camera2D
{
    [Export] private float _zoomSpeed;
    [Export] private float _movingSpeed;
    [Export] private float _minimalZoom;
    [Export] private float _maximumZoom;
    private Vector2 _movementTarget;
    
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("camera_zoom_in"))
            Zoom *= _zoomSpeed;
        if (@event.IsActionPressed("camera_zoom_out"))
            Zoom /= _zoomSpeed;
    }
}