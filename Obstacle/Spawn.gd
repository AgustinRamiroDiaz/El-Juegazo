extends KinematicBody

# speed of the obstacle in meters per second.
export var speed = 10

var velocity = Vector3.FORWARD * speed

func _physics_process(_delta):
	move_and_slide(velocity)


func _on_VisibilityNotifier_screen_exited():
	queue_free()
	
func initialize(start_position):
	translation = start_position
