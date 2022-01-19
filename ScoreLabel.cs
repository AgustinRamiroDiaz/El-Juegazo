using Godot;
using System;

public class ScoreLabel : Label
{
    public float score = 0;
    bool PlayerLost = false;
    public override void _Process(float delta)
    {
        if (PlayerLost) { return; }
        score += delta;
        Text = $"Score: {Math.Round(score * 5)}";
    }
    private void _on_Player_hit()
    {
        PlayerLost = true;
    }
}

