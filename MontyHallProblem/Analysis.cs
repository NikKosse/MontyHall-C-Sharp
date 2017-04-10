using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem
{
    public class Analysis
    {
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public double PercentWins { get; set; }
        public int TotalGames { get; set; }

        public void ComputePercentage()
        {
            TotalGames = WinCount + LossCount;
            PercentWins = ((double)WinCount / TotalGames) * 100.0;
            WinCount = 0;
            LossCount = 0;            
        }
    }
}
