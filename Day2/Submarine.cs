namespace Day2;

public class Submarine
{
    public int Distance { get; private set; }

    public int Depth { get; private set; }

    public int Aim { get; private set; }

    public void FollowInstruction(Instruction instruction)
    {
        switch (instruction.Direction)
        {
            case "up":
                Depth -= instruction.Distance;
                break;
            case "down":
                Depth += instruction.Distance;
                break;
            case "forward":
                Distance += instruction.Distance;
                break;
            default:
                throw new InvalidOperationException("Instruction Direction is not valid.");
        }
    }

    public void FollowInstructionWithAim(Instruction instruction)
    {
        switch (instruction.Direction)
        {
            case "up":
                Aim -= instruction.Distance;
                break;
            case "down":
                Aim += instruction.Distance;
                break;
            case "forward":
                Distance += instruction.Distance;
                Depth += instruction.Distance * Aim;
                break;
            default:
                throw new InvalidOperationException("Instruction Direction is not valid.");
        }
    }
}
