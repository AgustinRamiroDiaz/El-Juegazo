using Godot;
using System;

public partial class player_movement : CharacterBody3D
{
    [Export] float speed = 14;

    [Export] float fall_acceleration = 75;

	[Export] StaticBody3D ground;

    private Vector3 velocity = Vector3.Zero;

	private double leftLimit;
	private double rightLimit;
	public override void _Ready() {
		leftLimit = ground.Transform.origin.x - ground.Scale.x / 2;
		rightLimit = -leftLimit;
	}

    public override void _PhysicsProcess(double delta)
    {

        var direction = Vector3.Zero;
        if (Input.IsActionPressed("move_right") && Transform.origin.x < rightLimit)
        {
            direction.x += 1;
        }

        if (Input.IsActionPressed("move_left") && Transform.origin.x > leftLimit)
		{
			direction.x -= 1;
		}



        if (direction != Vector3.Zero)
        {
            direction = direction.Normalized();
        }

        velocity.x = direction.x * speed;

        Velocity = velocity;
        MoveAndSlide();

    }
    // signal management
    [Signal]
    public delegate void HitEventHandler();


    private void Die()
    {
        EmitSignal(SignalName.Hit); // This name is thightly coupled to the name of the signal :thinkging:
        QueueFree();
    }

    public void _on_ObstacleDetector_body_entered(Node body)
    {
        Die();
    }
}
