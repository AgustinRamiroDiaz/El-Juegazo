extends KinematicBody

# speed of the obstacle in meters per second.
export var speed = 10

export var gravity = 75

var velocity = Vector3.BACK * speed

func _physics_process(delta):
	velocity.y -= gravity * delta
	move_and_slide(velocity)


func _on_VisibilityNotifier_screen_exited():
	queue_free()
	
func initialize(start_position):
	translation = start_position
