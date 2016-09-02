using FunctionLib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLib
{
    public class SecondPartParser : ISecondPartParser
    {
        public string GetContent(string content, string startSymbol, string[] separator)
        {
            if (string.IsNullOrWhiteSpace(content)) return null;

            content = content.Trim();
            if (content.StartsWith(startSymbol))
            {
                var columns = content.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string output = "#";
                output += string.Join(",", columns);
                return output;
            }
            return null;
        }

        public string[] GetFooter(string line, string line1,string[] separator)
        {
            string[]lines=new string[2];
            lines[0] = string.Join(",", line.Split(separator, StringSplitOptions.RemoveEmptyEntries));
            lines[1] = string.Join(",", line1.Split(separator, StringSplitOptions.RemoveEmptyEntries));

            return lines;
        }

       

        public string[] GetHeader(string header, string date,string line2,string line3)
        {
            string [] lines=new string[3];
            string line1 = CommonRules.GetHeader(header);
            line1 += "," + string.Join(",", date.Replace("BK!AHA", "")
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            lines[0] = line1;
            lines[1]=string.Join(",", line2.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            lines[2]=string.Join(",",line3.Split(new[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries));
            return lines;
        }
    }
}
