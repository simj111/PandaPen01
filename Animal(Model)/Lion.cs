﻿using System;
using Interfaces;
using Interfaces.Events;

namespace AnimalModel
{
   public class Lion : IAnimalModle
    {
    /// <summary>
        /// The Data Members Contain string and doubles The Indvduul name is the specif of the object passed out to the BarMangers.
        /// The Doubles Contain Invidual BarVaules and are the Intial Valuse.
        /// The Events are the FristPassHandler is used to send out the Intial values when the system is Constrcuted
        /// </summary>
          private string IDVIDUALName;
          private string _imageName = "Lion";
          private double _inHBarVal = 5;
          private double _inEBarVal = 60;
          private double _inFBarVal = 75;
         private double _happinessBarVal = 1;

         double[] numbers;

        public ICalculate Calculator;
        public IBarManager barmanager;

       public event FirstPassHandler fPass;

      
        /// <summary>
        /// Is the Consructor for Panda it is used to transfer the Aninal its BarManger And Calulator
        /// Connect the Animal to its BarManger
        /// </summary>
        /// <param name="myBarManager"></param>
        /// <param name="calculator"></param>
        /// <param name="ID"></param>
        public Lion(IBarManager myBarManager, ICalculate calculator, int ID)
        {
            barmanager = myBarManager;
            Name(_imageName, ID);
            myBarManager.ConnectANIMAL(this, IDVIDUALName);
            Calculator = calculator;
            numbers = new double[4]{ _inHBarVal, _inEBarVal, _inFBarVal, _happinessBarVal };
        }

        /// <summary>
        /// Frist Pass Set UP is called in the Controler to pass the Inital star up Variables
        /// </summary>

        public void FristPassSetUP()
        {
            
            string imagename = _imageName;
            FirstPassArgs args = new FirstPassArgs(imagename, numbers);
            fPass(this, args);
        }

        /// <summary>
        /// Is Used in the controler to Get the Bars.
        /// </summary>
        /// <returns></returns>

        public IBarManager Getbars()
        {
      
            return barmanager;
        }

        /// <summary>
        /// used to set the indivual name of the class which is used to generate specific Events.
        /// </summary>
        /// <param name="_imageName"> this contains the name of the animal</param>
        /// <param name="ID">this contains the animal ID</param>
        /// <returns>Returns the name mixed with an ID e.g. "Lion01"</returns>
       public string Name(string _imageName, double ID)
        {
               IDVIDUALName = _imageName + ID.ToString();
               return IDVIDUALName;
        }

        /// <summary>
        /// Pass in the valuses for the Calulators.
        /// </summary>
        /// <param name="Operations"></param>
        public void Calculate(string Operations)
        {

            Calculator.CalculateValues(numbers, Operations);
            numbers = Calculator.Results();
            
        }

        public ICalculate Getcalc()
        {
            return Calculator;
        }
    }
}
