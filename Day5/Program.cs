using Common;
using Day5;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
    int numberOfSafePoints = GetNumberOfSafePoints(input, true);

    Console.WriteLine("Number of safe points: {0}", numberOfSafePoints);
}

static void Part2(string[] input)
{
    int numberOfSafePoints = GetNumberOfSafePoints(input, false);

    Console.WriteLine("Number of safe points: {0}", numberOfSafePoints);
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

static int GetNumberOfSafePoints(string[] input, bool excludeDiagonals)
{
    var map = new CoordinateMap<MapCoordinateHit>();

    foreach (var item in input)
    {
        var beginAndEndCoordinates = GetBeginAndEndCoordinates(item);
        var beginCoord = beginAndEndCoordinates.Item1;
        var endCoord = beginAndEndCoordinates.Item2;

        if (excludeDiagonals
            && !beginCoord.IsSameXAxisAs(endCoord)
            && !beginCoord.IsSameYAxisAs(endCoord))
        {
            continue;
        }

        var lineSegment = new LineSegment(beginCoord, endCoord);

        foreach (var coordinate in lineSegment.Coordinates)
        {
            if (map.TryGetValue(coordinate, out MapCoordinateHit? existingCoordinate))
            {
                existingCoordinate.Hit();
                continue;
            }

            map.Add(new MapCoordinateHit(coordinate.X, coordinate.Y));
        }
    }

    return map.Count(m => m.Count >= 2);
}