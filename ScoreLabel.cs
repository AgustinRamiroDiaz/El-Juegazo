using Godot;
using System;

public class ScoreLabel : Label
{
	public var score = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	score += delta;
	text = "Score: %s" % round(score * 5);
	
  }

}
//
//
//func _on_Player_hit():
//	# _process = x
//	pass
