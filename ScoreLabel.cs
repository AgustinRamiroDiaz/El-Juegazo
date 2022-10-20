using Godot;
using System;

public partial class ScoreLabel : Label
{
    public double score = 0;
    bool PlayerLost = false;
    public override void _Process(double delta)
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
