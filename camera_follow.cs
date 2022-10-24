using Godot;
using System;

public partial class camera_follow : Camera3D
{
	[Export]
	Node3D target;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (target  != null) {
			var currentOffset =  target.Transform.origin - Transform.origin;
			this.GlobalTranslate(currentOffset.Project(new Vector3(1, 0, 0)));
		}
	}
}
