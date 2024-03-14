using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 200.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float) delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_up ") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("ui_left", "ui_right");
		if (direction != 0)
		{
			
			velocity.X = Mathf.MoveToward(Velocity.X, direction * Speed, 10);
		}
		
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, 10);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
