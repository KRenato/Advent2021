using Common;
using Day2;

var input = await InputReader.GetInputAsync();

Console.WriteLine("Part 1" + Environment.NewLine);

Part1(input);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Part2(input);

static void Part1(string[] input)
{
    var submarine = new Submarine();

    foreach (var item in input)
    {
        var instruction = ProcessInstruction(item);
        submarine.FollowInstruction(instruction);
    }

    Console.WriteLine("Submarine depth: {0} distance: {1} product {2}.", submarine.Depth, submarine.Distance, submarine.Depth * submarine.Distance);
}

static void Part2(string[] input)
{
    var submarine = new Submarine();

    foreach (var item in input)
    {
        var instruction = ProcessInstruction(item);
        submarine.FollowInstructionWithAim(instruction);
    }

    Console.WriteLine("Submarine depth: {0} distance: {1} product {2}.", submarine.Depth, submarine.Distance, submarine.Depth * submarine.Distance);
}

static Instruction ProcessInstruction(string item)
{
    var splitInstruction = item.Split(' ');
    return new Instruction
    {
        Direction = splitInstruction[0],
        Distance = int.Parse(splitInstruction[1])
    };
}