using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
namespace CalculatorLibrary
{
    public class PandaCalculate : ICalculate
    {
        double[] answers;
        public event PassCalcResultsHandler resPass;

        public void CalculateValues(double[] numbers,string Operations)
        {
            if (Operations == "Eat")
            {
                numbers[0] = numbers[0] + 5;
                numbers[1]  = numbers[1] + 2;
                numbers[2] = numbers[2]- 5;
                answers = numbers;
            }
            else if (Operations == "Sleep")
            {
                numbers[0] -= 5;
                numbers[1] += 5;
                numbers[2] -= 2;
                answers = numbers;
            }
            else if (Operations == "Exercise")
            {
                numbers[0] -= 5;
                numbers[1] -= 10;
                numbers[2] += 10;
                answers = numbers;
            }
            PassCalcResultsArgs information = new PassCalcResultsArgs(answers);

            resPass(this, information); ;
        }

        public void CalculateHappines(double[] numbers)
        {
  
        }

        public double[] Results()
        {
            return answers;
        }

    }
}
