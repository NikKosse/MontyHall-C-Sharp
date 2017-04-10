using Microsoft.VisualStudio.TestTools.UnitTesting;
using MontyHallProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem.Tests
{
    [TestClass]
    public class AnalysisTests
    { 
        private Analysis _analysis; 

        [TestInitialize]
        public void Setup()
        {
            _analysis = new Analysis();
        }

        [TestCleanup]
        public void Teardown()
        {
            //_analysis.LossCount = 0;
            //_analysis.WinCount = 0;
            //_analysis.PercentWins = 0;
        }

        [TestMethod]
        public void ComputePercentageWins_Given6Wins4Losses_Returns60Percent()
        {
            _analysis.LossCount = 4;
            _analysis.WinCount = 6;
            var expected = 60;
            _analysis.ComputePercentage();
            var actual = _analysis.PercentWins;

            Assert.AreEqual(expected, actual);
        }
    }
}