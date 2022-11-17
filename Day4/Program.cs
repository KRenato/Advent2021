using Common;
using Day4;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
    var bingoBalls = input[0]
        .Split(',')
        .Select(s => int.Parse(s));

    var calledBingoBalls = new List<int>();

    var bingoCards = GetBingoCards(input, calledBingoBalls);

    foreach (var ball in bingoBalls)
    {
        calledBingoBalls.Add(ball);

        var winningCards = bingoCards.Where(c => c.HasWon());
        if (bingoCards.Any(c => c.HasWon()))
        {
            var winningCard = bingoCards.First(c => c.HasWon());
            break;
        }
    }
}

static void Part2(string[] input)
{

}

static List<BingoCard> GetBingoCards(string[] input, List<int> calledBingoBalls)
{
    var bingoCards = new List<BingoCard>();

    for (int i = 2; i < input.Length; i += 6)
    {
        var cardArray = new string[5];

        for (int j = 0; j < 5; j++)
        {
            cardArray[j] = input[i + j];
        }

        bingoCards.Add(new BingoCard(cardArray, calledBingoBalls));
    }

    return bingoCards;
}