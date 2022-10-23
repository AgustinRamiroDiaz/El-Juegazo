using Godot;
using System;

public partial class menu : Node2D
{
	[Export]
	public PackedScene main_scene;

	public void _on_button_pressed() {
		GetTree().ChangeSceneToPacked(main_scene);
	}
}
