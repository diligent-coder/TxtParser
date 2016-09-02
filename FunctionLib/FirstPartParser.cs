using FunctionLib.Interface;
using System;

namespace FunctionLib
{

    public class FirstPartParser : IFirstPartParser
    {
        public string GetContent(string content, string startSymbol, char[] separator, int[] columns)
        {
            if (string.IsNullOrWhiteSpace(content)) return null;

            content = content.Trim();
            if (content.StartsWith(startSymbol))
            {
                var cols = content.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string output = null;
                foreach (var column in columns)
                {
                    output += cols[column].Trim() + ",";
                }
                return output;
            }
            return null;
        }

        public string GetHeader(string header)
        {
            return CommonRules.GetHeader(header);
        }


    }
}
