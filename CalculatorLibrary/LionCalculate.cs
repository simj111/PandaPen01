using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;

namespace CalculatorLibrary
{

    public class LionCalculate : ICalculate
    {
        double[] answers;
        public event PassCalcResultsHandler resPass;
        public string InvidualCalulatorValue;
        private string _imageName = "Lion";
      
        public LionCalculate(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
        }

        public void CalculateValues(double[] numbers,string Operations)
          

        {
            if (Operations == "Eat")
            {
                numbers[0] = numbers[0] + 15;
                numbers[1]  = numbers[1] + 5;
                numbers[2] = numbers[2] - 10;
              
            }

            else if (Operations == "Sleep")
            {
              
                numbers[0] -= 10;
                numbers[1] += 15;
                numbers[2] -= 5;
                
            }

            else if (Operations == "Exercise")
            {
                numbers[0] -= 5;
                numbers[1] -= 10;
                numbers[2] += 25;
                
            }

            for (int i = 0; i < numbers.Length;i++ )
            {
                if (numbers[i] > 100)
                {
                    numbers[i] = 99;
                }
                else if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
                
            }

            answers = numbers;

            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalulatorValue);

            resPass(this, information);
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

    

