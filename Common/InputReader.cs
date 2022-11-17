namespace Common;

public static class InputReader
{
    private const string fileName = "input.txt";

    public static async Task<string[]> GetInputAsync()
    {
        return await File.ReadAllLinesAsync(fileName);
    }
}
