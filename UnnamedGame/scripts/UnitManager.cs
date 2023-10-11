using System.Collections.Generic;
using System.Linq;
using Godot;

namespace UnnamedGame.scripts;

public partial class UnitManager : Node2D
{
	[Export] private PackedScene _defaultUnit;
    private readonly List<Unit> _units = new ();
    
    public override void _Ready()
    {
    }
    
    public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
		}
		if (@event.IsActionPressed("right_click"))
		{
			foreach (var unit in _units.Where(unit => unit.isSelected))
			{
				unit.movementTarget = GetGlobalMousePosition();
				unit.isSelected = false;
				unit.DisableOutline();
			}
		}
		if (@event.IsActionPressed("press_1"))
		{
			SpawnUnit(new Vector2(100, 100));
		}
	}

    private void SpawnUnit(Vector2 pos)
    {
	    var unit = _defaultUnit.Instantiate<Unit>();
	    unit.Transform = new Transform2D(0, pos);
	    AddChild(unit);
	    _units.Add(unit);
    } 
}