using Common;

namespace Day5;

public class MapCoordinateHit: IMappedObject
{
    public MapCoordinateHit(int x, int y)
    {
        Coordinate = new Coordinate(x, y);
    }

    public Coordinate Coordinate { get; }

    public int Count { get; private set; } = 1;

    public void Hit()
    {
        Count++;
    }
}
