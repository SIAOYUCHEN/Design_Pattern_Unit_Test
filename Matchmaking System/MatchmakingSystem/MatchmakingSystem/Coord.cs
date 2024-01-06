namespace MatchmakingSystem;

public class Coord
{
    private readonly int x;
    private readonly int y;

    public Coord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X => x;
    public int Y => y;

    public double Distance(Coord coord)
    {
        int diffX = Math.Abs(x - coord.X);
        int diffY = Math.Abs(y - coord.Y);
        return Math.Sqrt(diffX * diffX + diffY * diffY);
    }
}