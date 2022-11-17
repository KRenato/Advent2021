namespace Day4;

public class BingoCardSquare
{
    public BingoCardSquare(int x, int y, int value)
    {
        X = x;
        Y = y;
        Value = value;
    }

    public int X { get; }

    public int Y { get; }

    public int Value { get; }

    public bool HasBeenCalled { get; set; } = false;
}
