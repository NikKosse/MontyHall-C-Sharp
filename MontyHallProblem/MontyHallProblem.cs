using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem
{
    public class MontyHallProblem
    {
        private Random _rand = new Random();

        public List<bool> Doors { get; set; }
        public int ChosenDoor { get; set; }
        public int DoorToRemove { get; set; }


        public void InitalizeList()
        {
            Doors = new List<bool>()
            {
                true,
                false,
                false
            };
        }

        public void ChooseDoor()
        {
            ChosenDoor = _rand.Next(0, 3);
        }

        public bool CheckIfCarChosen()
        {
            if (ChosenDoor == 0)
            {
                return true;
            }
            return false;
        }

        public void RemoveDoor()
        {
            var indexToRemove = _rand.Next(1, 3);
            indexToRemove = MakeSureDoorToBeRemovedIsNotChosenDoor();
            Doors.RemoveAt(DoorToRemove);
        }

        public int MakeSureDoorToBeRemovedIsNotChosenDoor()
        {
            while (DoorToRemove == ChosenDoor)
            {
                DoorToRemove = _rand.Next(1, 3);
            }
            return DoorToRemove;
        }

        public int SwitchDoor(bool switchDoor)
        {
            var newDoor = 0;
            if (switchDoor)
            {
                if (ChosenDoor == 0)
                {
                    newDoor = 1;
                }
                if (ChosenDoor == 1)
                {
                    newDoor = 0;
                }
                return newDoor;
            }
            return ChosenDoor;
        }
    }
}