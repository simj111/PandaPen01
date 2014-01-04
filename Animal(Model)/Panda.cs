using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using BarManager;
using CalculatorLibrary;

namespace AnimalModel
{
    public class Panda : IAnimalModle
    {
             private string IDVIDUALName;
          private string _imageName = "Panda";
          private double _inHBarVal = 15;
          private double _inEBarVal = 60;
          private double _inFBarVal = 5;
         private double _happinessBarVal = 0;

       
        public ICalculate Calculator;
        public IBarManager barmanager;

       public event FirstPassHandler fPass;

      
        
        public Panda(IBarManager myBarManager, ICalculate calculator, double ID)
        {
            barmanager = myBarManager;
            Name(_imageName, ID);
            myBarManager.ConnectANIMAL(this);
            Calculator = calculator;
            
        }

        public void FristPassSetUP()
        {
            double[] numbers = new double[4]{_inHBarVal,_inEBarVal,_inFBarVal,_happinessBarVal};
            string imagename = _imageName;
            FirstPassArgs args = new FirstPassArgs(imagename, numbers);
            fPass(this, args);
        }

        public IBarManager Getbars()
        {
      
            return barmanager;
        }

       
       public string Name(string _imageName, double ID)
        {
           

               IDVIDUALName = _imageName + ID.ToString();
               return IDVIDUALName;
        }


        public void Calculate(string Operations)
        {
            double[] numbers = new double[3] { _inHBarVal, _inEBarVal, _inFBarVal };
            Calculator.CalculateValues(numbers, Operations);
        
        
        }

        public void GetPicture()
        {

        }
    }
    }
