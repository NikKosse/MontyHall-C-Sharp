using Microsoft.VisualStudio.TestTools.UnitTesting;
using MontyHallProblem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace MontyHallProblem.Tests
{
    [TestClass]
    public class MontyHallProblemTests
    {
        private List<bool> _doors = new List<bool>()
            {
                true,
                false,
                false
            };
        private MontyHallProblem _montyHall;

        [TestInitialize]
        public void Initialize()
        {
            _montyHall = new MontyHallProblem();
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void CheckIfCarChosen_ReturnsTrueIfCarIsChosen()
        {
            var actual = _montyHall.CheckIfCarChosen();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckIfCarChosen_ReturnsFalseIfCarIsNotChosen()
        {
            _montyHall.ChosenDoor = 2;
            var actual = _montyHall.CheckIfCarChosen();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void RemoveDoor_RemovesADoor_ThatIsNotTheChosenDoor()
        {
            var expected = 2;
            _montyHall.DoorToRemove = 2;
            _montyHall.InitalizeList();
            _montyHall.RemoveDoor();
            var actual = _montyHall.Doors.Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void SwitchDoor_GivenTrue_SwitchesDoors()
        {
            var originalDoor = 2;

            var newDoor = _montyHall.SwitchDoor(true);

            Assert.AreNotEqual(newDoor, originalDoor);
        }

        [TestMethod]
        public void SwitchDoor_GivenFalse_DoesNotSwitchDoors()
        {
            _montyHall.ChosenDoor = 2;

            var newDoor = _montyHall.SwitchDoor(false);

            Assert.AreEqual(newDoor, _montyHall.ChosenDoor);
        }

        [TestMethod]
        public void ChooseDoor_ReturnsAValueBetweenZeroAndTwo()
        {
            _montyHall.ChooseDoor();
            bool fail = _montyHall.ChosenDoor < 0 || _montyHall.ChosenDoor > 2;
            Assert.IsFalse(fail);
        }

        [TestMethod]
        public void InitalizeList_ReturnsAListWithOneCar()
        {
            _montyHall.InitalizeList();
            var expected = 1;
            var actual = 0;

            foreach (bool door in _montyHall.Doors)
            {
                if (door == true)
                {
                    actual++;
                }
            }

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void MakeSureIndexIsNotChosenDoor_GivenChosenDoorEqualToIndexToRemove_ShouldNotReturnValueEqualToChosenDoor()
        {
            var chosenDoor = 2;
            _montyHall.ChosenDoor = chosenDoor;
            _montyHall.DoorToRemove = 2;

            var actual = _montyHall.MakeSureDoorToBeRemovedIsNotChosenDoor();

            Assert.AreNotEqual(chosenDoor, actual);
        }
    }
}