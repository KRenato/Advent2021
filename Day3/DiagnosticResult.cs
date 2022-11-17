using System.Collections;

namespace Day3;

public class DiagnosticResult
{
    private readonly int _binaryLength;
    private readonly List<BitArray> _diagnosticData;

    public DiagnosticResult(string[] input)
    {
        _binaryLength = input[0].Length;

        _diagnosticData = new List<BitArray>();

        Gamma = new BitArray(_binaryLength);
        Epsilon = new BitArray(_binaryLength);
        Oxygen = new BitArray(_binaryLength);
        CO2 = new BitArray(_binaryLength);

        SetDiagnosticData(input);
        SetPowerInputs();
        SetLifeSupportInputs();
    }

    public BitArray Gamma { get; }

    public BitArray Epsilon { get; }

    public BitArray Oxygen { get; private set; }

    public BitArray CO2 { get; private set; }

    public int PowerConsumption => BinaryToDecimal(Gamma) * BinaryToDecimal(Epsilon);

    public int LifeSupportRating => BinaryToDecimal(Oxygen) * BinaryToDecimal(CO2);

    private void SetDiagnosticData(string[] input)
    {
        foreach (var item in input)
        {
            var diagnosticValue = new BitArray(_binaryLength);
            for (int i = 0; i < _binaryLength; i++)
            {
                diagnosticValue[i] = item[i] == '1';
            }
            _diagnosticData.Add(diagnosticValue);
        }
    }

    private void SetPowerInputs()
    {
        for (int i = 0; i < _binaryLength; i++)
        {
            var hasMoreOnes = _diagnosticData.Count(item => item[i]) >= _diagnosticData.Count / 2;
            Gamma[i] = hasMoreOnes;
            Epsilon[i] = !hasMoreOnes;
        }
    }

    private void SetLifeSupportInputs()
    {
        var oxygenMatches = new List<BitArray>(_diagnosticData);
        var co2Matches = new List<BitArray>(_diagnosticData);

        for (int i = 0; i < _binaryLength; i++)
        {
            if (oxygenMatches.Count > 1)
            {
                var hasMoreOnes = oxygenMatches.Count(item => item[i]) >= oxygenMatches.Count / 2f;
                oxygenMatches = oxygenMatches.Where(m => m[i] == hasMoreOnes).ToList();
            }

            if (co2Matches.Count > 1)
            {
                var hasFewerOnes = co2Matches.Count(item => item[i]) < co2Matches.Count / 2f;
                co2Matches = co2Matches.Where(m => m[i] == hasFewerOnes).ToList();
            }

            if (oxygenMatches.Count == 1 && co2Matches.Count == 1)
            {
                break;
            }
        }

        Oxygen = oxygenMatches.First();
        CO2 = co2Matches.First();
    }

    private static int BinaryToDecimal(BitArray bitArray)
    {
        int value = 0;

        for (int i = 0; i < bitArray.Count; i++)
        {
            var position = bitArray.Count - 1 - i;

            if (bitArray[position])
                value += Convert.ToInt16(Math.Pow(2, i));
        }

        return value;
    }
}
