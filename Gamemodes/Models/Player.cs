namespace Gamemodes.Models;

public class Player
{
    public string Name { get; set; }
    public int Victories { get; set; } = 0;
    public int Losses { get; set; } = 0;
}