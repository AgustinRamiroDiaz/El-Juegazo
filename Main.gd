extends Node

@export var obstacle_scene: PackedScene
@export var spawn_location: PathFollow3D

# Called when the node enters the scene tree for the first time.
func _ready():
	randomize()
	
func _on_ObtacleTimer_timeout():
	# Create a obstacle instance and add it to the scene.
	var obstacle = obstacle_scene.instantiate()

	# TODO: fix this
	obstacle.initialize(spawn_location.translation)
	add_child(obstacle)


func _on_Player_hit():
	$ObtacleTimer.stop()
	$UI/Retry.show()
	$UI/Retry/Button.grab_focus()
