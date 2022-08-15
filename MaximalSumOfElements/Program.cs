namespace MaximalSumOfElements;

public static class Program
{
    public static void Main(string[] args)
    {
        string path = string.Empty;

        if (args.Length == 0)
        {
            Console.Write("Write the file name: ");
            path = Console.ReadLine();
        }
        else
        {
            path = args.First();
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("Path wrong!");
            return;
        }

        ReadFile(path);
    }

    private static void ReadFile(string path)
    {
        var readingFile = FileHandler.ReadFile(path);

        if (readingFile.LineWithMaxSun > 0)
        {
            Console.WriteLine($"{readingFile.LineWithMaxSun} line has a max sum");
        }
        else if (readingFile.BrokenLines.Count == 0)
        {
            Console.WriteLine("File empty!");
        }
        else
        {
            Console.WriteLine("Not sum");
        }

        readingFile.BrokenLines.ForEach(id => Console.WriteLine($"{id} line: contains wrong elements"));
    }
}