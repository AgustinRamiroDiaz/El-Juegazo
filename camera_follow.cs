using Godot;
using System;

public partial class camera_follow : Camera3D
{
	[Export]
	Node3D target;
	[Export]
	double lerpSpeed = 0.1;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (target  != null) {
			var currentOffset =  target.Transform.origin - Transform.origin;
			this.GlobalTranslate(currentOffset.Project(new Vector3(1, 0, 0)));
		}
	}
}
