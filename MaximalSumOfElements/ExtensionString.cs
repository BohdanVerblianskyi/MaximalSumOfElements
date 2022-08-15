using System.Globalization;

namespace MaximalSumOfElements;

public static class ExtensionString
{
    public static double GetSumOnTheLine(this string line)
    {
        const string separator = ",";
        
        if (string.IsNullOrEmpty(line))
            throw new NotParseException();

        var splitLine = line.Split(separator).Where(l => !string.IsNullOrEmpty(l)).ToList();
        double sum = 0;

        foreach (var number in splitLine)
        {
            if (double.TryParse(number,NumberStyles.Any, CultureInfo.InvariantCulture,out double result))
            {
                sum += result;
            }
            else
            {
                throw new NotParseException();
            }
        }
        
        return sum;
    }
}