using Common;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
    int? previousValue = null;
    int increases = 0;

    foreach (var item in input)
    {
        int depth = int.Parse(item);

        if (previousValue is not null && depth > previousValue)
        {
            increases++;
        }

        previousValue = depth;
    }

    Console.WriteLine("Depth has increased {0} times.", increases);
}

static void Part2(string[] input)
{
    var previousValues = new int?[3];

    int increases = 0;

    foreach (var item in input)
    {
        int depth = int.Parse(item);

        if (previousValues.All(v => v.HasValue)
            && depth + previousValues[0] + previousValues[1] > previousValues.Sum())
        {
            increases++;
        }

        for (int i = 2; i > 0; i--)
        {
            previousValues[i] = previousValues[i - 1];
        }

        previousValues[0] = depth;
    }

    Console.WriteLine("Rolling depth has increased {0} times.", increases);
}