using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLib.Tests
{
    [TestClass()]
    public class TxtExtractorManagerTests
    {
        [TestMethod()]
        public void ExtractFileTest()
        {
            new TxtExtractorManager().ExtractFile(@"1DD695R.txt");
        }
    }
}