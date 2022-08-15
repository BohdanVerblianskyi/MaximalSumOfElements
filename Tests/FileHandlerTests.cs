using System.Reflection;
using System.Text;
using MaximalSumOfElements;

namespace Tests;

public class FileHandlerTests
{
    private static readonly string TestFileWithoutCorrectLines0 = "testFileWithoutCorrectLines0";
    private static readonly string TestFileWithoutCorrectLines1 = "testFileWithoutCorrectLines1";
    private static readonly string TestFileWithCorrectLines0 = "testFileWithCorrectLines0";
    private static readonly string TestFileWithCorrectLines1 = "testFileWithCorrectLines1";

    [Theory]
    [MemberData(nameof(TestFileWithCorrectLines_Data))]
    [MemberData(nameof(TestFileWithoutCorrectLines_Data))]
    public void LineWithMaxSumAndBrokenLines_Equal(string path, int expectedLineWithMaxSum,
        List<int> expectedBrokenLines)
    {
        var actualReadingResult = FileHandler.ReadFile(path);

        Assert.Equal(expectedLineWithMaxSum, actualReadingResult.LineWithMaxSun);
        Assert.Equal(expectedBrokenLines, actualReadingResult.BrokenLines);
    }

    public static IEnumerable<object[]> TestFileWithCorrectLines_Data()
    {
        yield return new object[]
            { Path.Combine(Directory.GetCurrentDirectory(), TestFileWithCorrectLines0), 2, new List<int> { 3,4,5 } };
        yield return new object[]
            { Path.Combine(Directory.GetCurrentDirectory(), TestFileWithCorrectLines1), 1, new List<int> { 2 } };
    }

    public static IEnumerable<object[]> TestFileWithoutCorrectLines_Data()
    {
        yield return new object[]
            {  Path.Combine(Directory.GetCurrentDirectory(), TestFileWithoutCorrectLines0), -1, new List<int> { 1, 2 } };
        yield return new object[]
            { Path.Combine(Directory.GetCurrentDirectory(), TestFileWithoutCorrectLines1), -1, new List<int> { 1, 2 } };
    }

}