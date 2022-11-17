using Common;
using Day3;

var input = await InputReader.GetInputAsync();
var result = new DiagnosticResult(input);

Console.WriteLine("Part 1" + Environment.NewLine);

Console.WriteLine("Power consumption: {0}", result.PowerConsumption);

Console.WriteLine(Environment.NewLine + "Part 2" + Environment.NewLine);

Console.WriteLine("Life support rating: {0}", result.LifeSupportRating);