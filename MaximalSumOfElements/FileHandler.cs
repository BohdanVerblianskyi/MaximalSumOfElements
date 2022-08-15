using System.Globalization;

namespace MaximalSumOfElements;

public static class FileHandler
{
    public static FileHandlerOutput ReadFile(string pathToFile)
    {
        if (pathToFile == null)
            throw new ArgumentNullException(nameof(pathToFile));

        using StreamReader streamReader = new StreamReader(pathToFile);
        double currentSum = double.MinValue;
        int lineWithMaxSum = -1;
        List<int> brokenLines = new List<int>();
        int currentLine = 1;

        while (streamReader.ReadLine() is { } line)
        {
            try
            {
                var result = line.GetSumOnTheLine();
                if (currentSum < result)
                {
                    currentSum = result;
                    lineWithMaxSum = currentLine;
                }
            }
            catch (NotParseException)
            {
                brokenLines.Add(currentLine);
            }
            
            currentLine++;
        }

        streamReader.Close();

        return new FileHandlerOutput(lineWithMaxSum,brokenLines);
    }
}