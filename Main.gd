extends Node

export (PackedScene) var obstacle_scene
export var spawn_distance = 30
export var path_width = 20

var half_width = path_width / 2

# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	
func _on_ObtacleTimer_timeout():
	# Create a obstacle instance and add it to the scene.
	var obstacle = obstacle_scene.instance()

	# And give it a random offset.
#	#obstacle_spawn_location.unit_offset = randf()


	add_child(obstacle)
	obstacle.initialize(Vector3(rand_range(-half_width, half_width), 10, -spawn_distance))


func _on_Player_hit():
	$ObtacleTimer.stop()
	$UI/Retry.show()
	$UI/Retry/Button.grab_focus()
