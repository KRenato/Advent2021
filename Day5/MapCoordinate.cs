namespace Day5;

public class MapCoordinate
{
    public MapCoordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }

    public int Y { get; }

    public int Hits { get; private set; }

    public void IncrementHits()
    {
        Hits++;
    }
}
