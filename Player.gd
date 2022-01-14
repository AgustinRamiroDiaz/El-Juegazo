extends KinematicBody

export var speed = 14

export var fall_acceleration = 75

var velocity = Vector3.ZERO

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
		# $Pivot.look_at(translation + direction, Vector3.UP)
		
	velocity.x = direction.x * speed
	velocity = move_and_slide(velocity, Vector3.UP)
