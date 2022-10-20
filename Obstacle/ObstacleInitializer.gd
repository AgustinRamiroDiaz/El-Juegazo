extends CharacterBody3D

# speed of the obstacle in meters per second.
@export var speed = 10

@export var gravity = 75

var current_velocity = Vector3.BACK * speed

func _physics_process(delta):
	current_velocity.y -= gravity * delta
	set_velocity(current_velocity)
	move_and_slide()
	current_velocity


func _on_VisibilityNotifier_screen_exited():
	queue_free()
	
func initialize(start_position):
	position = start_position
