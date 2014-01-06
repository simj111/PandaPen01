using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;


namespace CalculatorLibrary
{
    public class GoldFishCalculator : ICalculate
    {
        public event PassCalcResultsHandler resPass;
        double[] answers;
        private string _imageName = "GoldFish2Bars";
        private string InvidualCalulatorValue;
        public GoldFishCalculator(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
        }


        public void CalculateValues(double[] numbers, string Operations)
        {
            if (Operations == "EatFishFood")
            {
                numbers[0] = numbers[0] + 15;
                numbers[1] = numbers[1] + 5;
             

            }

            else if (Operations == "CleaningAir")
            {
                numbers[0] = numbers[0] + 15;
                numbers[1] = numbers[1] + 5;
               
            }
            answers = numbers;

            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalulatorValue);
            resPass(this, information);
        }

        public void CalculateHappines(double[] numbers)
        {
          //  throw new NotImplementedException();
        }

        public double[] Results()
        {
            return answers;
        }

    }
}
