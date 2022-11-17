using Common;
using Day5;
using System.Runtime.CompilerServices;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
    foreach (var item in input)
    {
        var beginAndEndCoordinates = GetBeginAndEndCoordinates(item);
        var LineCoordinates = ExpandCoordinatesToLine(beginAndEndCoordinates.Item1, beginAndEndCoordinates.Item2);
    }
}

static void Part2(string[] input)
{
}

static (Coordinate, Coordinate) GetBeginAndEndCoordinates(string input)
{
    string marker = " -> ";
    int markerIndex = input.IndexOf(marker);

    var beginCoordinate = input[..markerIndex]
        .Split(',')
        .Select(int.Parse)
        .ToArray();

    var endCoordinate = input[(markerIndex + marker.Length)..]
        .Split(',')
        .Select(int.Parse)
        .ToArray();

    return new(new Coordinate(beginCoordinate), new Coordinate(endCoordinate));
}

static List<Coordinate> ExpandCoordinatesToLine(Coordinate origin, Coordinate endpoint)
{
    var line = new List<Coordinate>();

    return line;
}