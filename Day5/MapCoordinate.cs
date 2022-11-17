namespace Day5;

public class MapCoordinate
{
    public MapCoordinate(int x, int y)
    {
        Coordinate = new Coordinate(x, y);
    }

    public Coordinate Coordinate { get; }

    public int Hits { get; private set; }

    public void IncrementHits()
    {
        Hits++;
    }
}
