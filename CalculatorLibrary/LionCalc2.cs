using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;

namespace CalculatorLibrary
{
    public class LionCalc2 : ICalculate
    {
        public string InvidualCalulatorValue;
         private string _imageName = "Lion";
        public event FullHappinessHandler happiness;

        public event PassCalcResultsHandler resPass;

        public string InitialPassIn(int IDvalue)
        {
           InvidualCalulatorValue = _imageName + IDvalue.ToString();
            return InvidualCalulatorValue;
           
        }

        public void CalculateValues(double[] numbers, string Operations)
        {
            
        }

        public void CalculateHappines(double[] numbers)
        {
            
        }

        public double[] Results()
        {
            throw new NotImplementedException();
        }
    }
}
