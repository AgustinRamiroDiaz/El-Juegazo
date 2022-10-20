extends CharacterBody3D

@export var speed = 14

@export var fall_acceleration = 75


func _physics_process(delta):
	# We create a local variable to store the input direction.
	var direction = Vector3.ZERO

	# We check for each move input and update the direction accordingly.
	if Input.is_action_pressed("move_right"):
		direction.x += 1
	if Input.is_action_pressed("move_left"):
		direction.x -= 1
		
	if direction != Vector3.ZERO:
		direction = direction.normalized()
		# TODO: investigar si hace falta girar al jugador
		# $Pivot.look_at(position + direction, Vector3.UP)
		
	velocity.x = direction.x * speed
	set_velocity(velocity)
	set_up_direction(Vector3.UP)
	move_and_slide()

# Emitted when the player was hit by a obstacle
signal hit

func die():
	emit_signal("hit")
	queue_free()

func _on_ObstacleDetector_body_entered(body):
	
	die()

