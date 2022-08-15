using MaximalSumOfElements;

namespace Tests;

public class ExtensionStringTest
{
    
    [Theory]
    [InlineData(10,"4.5,5.5")]
    [InlineData(15,"5,5,5")]
    public void GetSumOnTheLine_Equal(double expected, string line)
    {
        var actual = line.GetSumOnTheLine();
        
        Assert.Equal(expected,actual);
    }

    [Theory]
    [InlineData("4.5,5.z")]
    [InlineData("5,b,5")]
    public void GetSumOnTheLine_ThrowsNotParseException(string line)
    {
        Assert.Throws<NotParseException>(() => line.GetSumOnTheLine());
    }
    
}