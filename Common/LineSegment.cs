using System.Diagnostics.Metrics;

namespace Common;

public class LineSegment
{
    public LineSegment(Coordinate first, Coordinate second)
    {
        Map(first, second);
    }

    public List<Coordinate> Coordinates { get; private set; } = new();

    private void Map(Coordinate first, Coordinate second)
    {
        if (first.IsSameXAxisAs(second))
        {
            MapByYAxis(first, second);
            return;
        }

        MapBySlope(first, second);
    }

    private void MapByYAxis(Coordinate first, Coordinate second)
    {
        int beginY = Math.Min(first.Y, second.Y);
        int endY = Math.Max(first.Y, second.Y);

        for (int i = beginY; i <= endY; i++)
        {
            Coordinates.Add(new Coordinate(first.X, i));
        }
    }

    private void MapBySlope(Coordinate first, Coordinate second)
    {
        int beginX = Math.Min(first.X, second.X);
        int endX = Math.Max(first.X, second.X);

        int rise = second.Y - first.Y;
        int run = second.X - first.X;

        int slope = rise / run;

        for (int i = beginX; i <= endX; i++)
        {
            var Y = (slope * (i - first.X)) + first.Y;
            Coordinates.Add(new Coordinate(i, Y));
        }
    }
}
