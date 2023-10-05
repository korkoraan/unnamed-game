using System;
using System.Collections.Generic;
using Godot;
namespace UnnamedGame.scripts;

public partial class SelectionArea : Node2D
{
	private bool _dragging;
	[Export] private Color _color;
	private Vector2 _dragStart;
	private Rect2 _rect;

	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{
		if (_dragging)
			QueueRedraw();
	}
	public override void _Draw()
	{
		if (_dragging)
		{
			_rect = new Rect2(_dragStart, GetGlobalMousePosition() - _dragStart);
			DrawRect(_rect, _color, false);
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
			_dragging = true;
			_dragStart = GetGlobalMousePosition();
			SetProcess(true);
		}
		if (@event.IsActionReleased("left_click"))
		{
			_dragging = false;
			var dragEnd = GetGlobalMousePosition();
			var space = GetWorld2D().DirectSpaceState;
			var query = new PhysicsShapeQueryParameters2D();
			query.Transform = new Transform2D(0, (_dragStart + dragEnd) / 2);
			query.Shape = new RectangleShape2D { Size = _rect.Size.Abs() };
			//max 1000 units in one go
			var selected = space.IntersectShape(query, 1000);
			foreach (var item in selected)
			{
				if (item["collider"].Obj is Unit unit)
				{
					unit.isSelected = true;
					unit.EnableOutline();
				}

			}
			QueueRedraw();
			SetProcess(false);
			GD.Print(_rect.Size);
		}
	}
}