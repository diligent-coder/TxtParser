using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace FunctionLib
{
    public class TxtExtractorManager
    {
        public void ExtractFile(string filePath)
        {
            var config = XmlHelper.XmlToObject<Config>("config.xml");

            string outPutDirectoy = ConfigurationManager.AppSettings["successFolder"];
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            try
            {
                var lines = LoadFile(filePath).ToArray();
                List<string[]> parts = SplitContent(lines);
                string[] firstPart = parts[0], secondPart = parts[1];

                string outputFilename = Path.Combine(outPutDirectoy, date
                    , $"{Path.GetFileNameWithoutExtension(filePath)}.csv");

                CreateDirectoryIfNotExists(outputFilename);

                using (StreamWriter writer = new StreamWriter(outputFilename,false, Encoding.UTF8))
                {
                    WriteFirstPart(firstPart, writer, config.firstpart);
                    WriteSecondPart(secondPart, writer,config.secondpart);
                }
            }
            catch (Exception ex)
            {
                outPutDirectoy = ConfigurationManager.AppSettings["failedFolder"];
            }
        }

        private void CreateDirectoryIfNotExists(string filename)
        {
            string directory = Path.GetDirectoryName(filename);
            if (directory != null && !Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }

        private IEnumerable<string> LoadFile(string filePath)
        {
            return File.ReadLines(filePath).Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => l.Trim());
        }

        private List<string[]> SplitContent(string[] lines)
        {
            var index = Array.FindIndex(lines, 1, StartsWithDo);
            List<string[]> parts = new List<string[]>();
            parts.Add(lines.Take(index).ToArray());
            parts.Add(lines.Skip(index).ToArray());
            return parts;
        }

        private bool StartsWithDo(string s)
        {
            string splitSymbol = ConfigurationManager.AppSettings["splitSymbol"];
            return !string.IsNullOrEmpty(s) && s.StartsWith(splitSymbol);
        }

        private void WriteFirstPart(string[] messages, StreamWriter writer, configFirstpart firstPart)
        {
            var header = firstPart.header;
            string firstLine = header.firstline;
            writer.WriteLine(firstLine);
 
            FirstPartParser firstPartParser = new FirstPartParser();
            writer.WriteLine(firstPartParser.GetHeader(messages[header.index]));

            var content = firstPart.content;
            for (int i = content.index; i < messages.Length; i++)
            {
                string startSymbol = content.start;
                var separator = content.separator.ToCharArray();
                string output = firstPartParser.GetContent(messages[i]
                    , startSymbol, separator, content.columns.Split(',').Select(int.Parse).ToArray());
                if (!string.IsNullOrEmpty(output))
                {
                    writer.WriteLine(output);
                }
            }
        }

        private void WriteSecondPart(string[] messages,StreamWriter writer, configSecondpart configSecondpart)
        {
         
            writer.WriteLine();
            writer.WriteLine();
            var header = configSecondpart.header;
            string secondLine = header.firstline;
            writer.WriteLine(secondLine);

            SecondPartParser secondPartParser = new SecondPartParser();
            string[] head = secondPartParser.GetHeader(messages[header.index], messages[header.dateIndex]
                , messages[header.line2Index], messages[header.line3Index]);
            foreach (var s in head)
            {
                writer.WriteLine(s);
            }

            var content = configSecondpart.content;
            for (int i = content.index; i < messages.Length-content.lastIndex; i++)
            {
                string startSymbol = content.start;
                var separator = content.separator.Split(';');
                string contentOutput = secondPartParser.GetContent(messages[i]
                    , startSymbol, separator);
                if (!string.IsNullOrEmpty(contentOutput))
                {
                    writer.WriteLine(contentOutput);
                }
            }

            var footer= configSecondpart.footer;
            string[] foot = secondPartParser.GetFooter(messages[messages.Length-footer.index1], messages[messages.Length - footer.index2],footer.separator.Split(';'));
            foreach (var s in foot)
            {
                writer.WriteLine(s);
            }
        }
    }
}

