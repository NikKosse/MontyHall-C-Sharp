using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MontyHallProblem;

namespace MontyHallProblem
{
    public class Program
    {
        private static MontyHallProblem _montyHall = new MontyHallProblem();
        private static Analysis _resultsAnalysis = new Analysis();
        static void Main(string[] args)
        {
            bool switchDoors = false;
            
            while (true)
            {
                Console.WriteLine("How many times do you want the Monty Hall Simulation to run?");
                var numberOfTimesToRun = Console.ReadLine();
                var timesToRun = Convert.ToInt32(numberOfTimesToRun);

                Console.WriteLine("Yes or no: do you want to switch doors when given the chance?");
                var wantToSwitch = Console.ReadLine();

                if (wantToSwitch == "yes") switchDoors = true;
                if (wantToSwitch == "no") switchDoors = false;
                PlayGame(timesToRun, switchDoors);         
            }
        }

        public static void PlayGame(int timesToRun, bool switchDoors)
        {
            for (int i = 0; i < timesToRun; i++)
            {
                _montyHall.InitalizeList();
                _montyHall.ChooseDoor();
                Console.WriteLine($"chosen door is: {_montyHall.ChosenDoor}");
                _montyHall.RemoveDoor();
                _montyHall.ChosenDoor = _montyHall.SwitchDoor(switchDoors);
                Console.WriteLine($"new door is: {_montyHall.ChosenDoor}");
                var win = _montyHall.CheckIfCarChosen();
                if(win == true) _resultsAnalysis.WinCount++;
                if (win == false) _resultsAnalysis.LossCount++;
            }

            Console.WriteLine("Results are: ");
            Console.WriteLine($"Number of wins: {_resultsAnalysis.WinCount}");
            Console.WriteLine($"Number of loses: {_resultsAnalysis.LossCount}");
            _resultsAnalysis.ComputePercentage();
            Console.WriteLine($"Win percentage: {_resultsAnalysis.PercentWins}");
        }
    }
}
