using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaPen;
using Interfaces.Events;
using Interfaces;
using AnimalModel;
using CalculatorLibrary;
using Interfaces.Events;
using System.Windows.Forms;

namespace TestProject2
{
    [TestClass]
    public class Win_Test
    {
        DefaultView d = new DefaultView(); 
        [TestMethod]
        public void Windcondtiontest()
        {
           
            Controller alpa = new Controller(d);
            alpa.ComposeContainer();
            //alpa.AFac1.GenerateAnimals("Panda", 0, "Panda_Easy");
            //List<IAnimalModel> actual = alpa.AFac1.animallist;
            ICalculate cal = new  PandaCalculate();
            FullHappinessArgs Happiness = new FullHappinessArgs("HappinessisfullPanda", "Panda0");
            alpa.NumberOfViews = 2;
            alpa.CheckWinCondition(cal, Happiness);
            alpa.CheckWinCondition(cal, Happiness);
            int actual = alpa.WinCalculation;
            int Expected = 2;
            Assert.AreEqual(actual, Expected);

        }
    }
}
