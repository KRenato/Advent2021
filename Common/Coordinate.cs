namespace Common;

public readonly struct Coordinate : IEquatable<Coordinate>
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coordinate(int[] points)
    {
        X = points[0];
        Y = points[1];
    }

    public int X { get; }

    public int Y { get; }

    public bool IsSameXAxisAs(Coordinate other)
    {
        return X == other.X;
    }

    public bool IsSameYAxisAs(Coordinate other)
    {
        return Y == other.Y;
    }

    public bool Equals(Coordinate other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Coordinate coordinate && Equals(coordinate);
    }

    public static bool operator == (Coordinate left, Coordinate right)
    {
        return left.Equals(right);
    }

    public static bool operator != (Coordinate left, Coordinate right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
