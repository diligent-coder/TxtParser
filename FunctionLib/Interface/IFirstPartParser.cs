namespace FunctionLib.Interface
{
    public interface IFirstPartParser
    {
        string GetHeader(string header);
        string GetContent(string content, string startSymbol, char[] separator, int[] columns);
    }
}
