namespace FunctionLib.Interface
{
    public interface ISecondPartParser
    {
        string[] GetHeader(string header, string date, string line2, string line3);
        string GetContent(string content, string startSymbol, string[] separator);
        string[] GetFooter(string line, string line1, string[] separator);
    }
}
