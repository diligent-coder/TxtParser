using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLib.Tests
{
    [TestClass()]
    public class FirstPartParserTests
    {
        [TestMethod()]
        public void GetContentTest()
        {
            string message = "BK%+%;%C%H!tHA      BK#N#OHA         BK8|HA BK$_HA        BKHfDq93HA        BKH=HA BKDjHA";
            FirstPartParser parser = new FirstPartParser();
            string content = parser.GetContent(message, "BK!tHA", new[] { '-', ' ' }, new[] { 1, 2, 3, 5, 4 });
            Assert.IsNull(content);

            message = "    BK!tHA  4 -  1        1           501           0.0146      ";
            content = parser.GetContent(message, "BK!tHA", new[] { '-', ' ' }, new[] { 1, 2, 3, 5, 4 });
            Assert.AreEqual(content, "4,1,1,0.0146,501,");

            message = "インピーダンス ";
            content = parser.GetContent(message, "BK!tHA", new[] { '-', ' ' }, new[] { 1, 2, 3, 5, 4 });
            Assert.IsNull(content);
        }
    }
}