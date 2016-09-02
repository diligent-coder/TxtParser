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
    public class CommonRulesTests
    {
        [TestMethod()]
        public void GetHeaderTest()
        {
            string header = CommonRules.GetHeader(" BK!v#S#T#M#6#P#5#2#1#6#8#L#CHA    (1DD695R)");
            Assert.AreEqual(header, "STM6P52168LCHA,1DD695R");
             header = CommonRules.GetHeader("BK!v!!#S#T#M#6#P#5#2#1#6#8#L#CHA  (1DD695R)");
            Assert.AreEqual(header, "STM6P52168LCHA,1DD695R");
        }
    }
}