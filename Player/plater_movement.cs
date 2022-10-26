using Godot;
using System;

public partial class plater_movement : CharacterBody3D
{
    [Export] float speed = 14;

    [Export] float fall_acceleration = 75;

    private Vector3 velocity = Vector3.Zero;

    public override void _PhysicsProcess(double delta)
    {
        var direction = Vector3.Zero;
        if (Input.IsActionPressed("move_right"))
        {
            direction.x += 1;
        }

        if (Input.IsActionPressed("move_left"))
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