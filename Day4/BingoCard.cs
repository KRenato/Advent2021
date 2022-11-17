namespace Day4;

public class BingoCard
{
    private readonly BingoCardSquare[] _squares = new BingoCardSquare[25];
    private readonly List<int> _calledBingoBalls;

    public BingoCard(string[] input, List<int> calledBingoBalls)
    {
        SetSquares(input);
        _calledBingoBalls = calledBingoBalls;
    }

    public bool HasWon()
    {
        var hasHorizontalWin = _squares
            .Where(SquareHasBeenCalled)
            .GroupBy(s => s.X)
            .Select(g => g.Count())
            .Any(g => g == 5);

        var hasVerticalWin = _squares
            .Where(SquareHasBeenCalled)
            .GroupBy(s => s.Y)
            .Select(g => g.Count())
            .Any(g => g == 5);

        return hasHorizontalWin || hasVerticalWin;
    }

    public int GetScore()
    {
        return _squares
            .Where(s => !SquareHasBeenCalled(s))
            .Sum(s => s.Value);
    }

    private void SetSquares(string[] input)
    {
        for (int i = 0; i < 5; i++)
        {
            var row = input[i]
                .Split(' ')
                .Where(r => !string.IsNullOrEmpty(r))
                .Select(int.Parse)
                .ToArray();

            for (int j = 0; j < 5; j++)
            {
                int idx = i * 5 + j;
                _squares[idx] = new BingoCardSquare(i, j, row[j]);
            }
        }
    }

    private bool SquareHasBeenCalled(BingoCardSquare square)
    {
        return _calledBingoBalls.Any(b => b == square.Value);
    }
}