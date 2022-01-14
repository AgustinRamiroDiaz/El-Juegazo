extends Node

export (PackedScene) var obstacle_scene


# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	


func _on_ObtacleTimer_timeout():
	# Create a obstacle instance and add it to the scene.
	var obstacle = obstacle_scene.instance()

	# And give it a random offset.
#	#obstacle_spawn_location.unit_offset = randf()


	add_child(obstacle)
	obstacle.initialize(Vector3.UP)
