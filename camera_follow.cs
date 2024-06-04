using Godot;
using System;

public partial class camera_follow : Camera3D
{
	[Export]
	Node3D target;
	[Export]
	float lerpSpeed = 0.1f;

	Vector3 offset;

	public override void _Ready()
	{
		offset = GlobalTransform.Origin - target.GlobalTransform.Origin;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (target != null)
		{
			var newPosition = target.GlobalTransform.Origin + offset;
			Transform = Transform.InterpolateWith(new Transform3D(target.Basis, newPosition), lerpSpeed);
		}
	}
}
