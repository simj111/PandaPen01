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
        #region DataMembers
        double[] answers;
        public event PassCalcResultsHandler resPass;
        public string InvidualCalulatorValue;
        private string _imageName = "Panda";
        #endregion

        #region Constructor
        public PandaCalculate(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
        }
        #endregion

        #region Metods
        public void CalculateValues(double[] numbers, string Operations)
        {
            if (Operations == "Eat")
            {
                numbers[0] = numbers[0] + 4;
                numbers[1] = numbers[1] + 2;
                numbers[2] = numbers[2] - 1;

            }

            else if (Operations == "Sleep")
            {

                numbers[0] -= 2;
                numbers[1] += 4;
                numbers[2] -= 1;

            }

            else if (Operations == "Exercise")
            {
                numbers[0] -= 6;
                numbers[1] -= 6;
                numbers[2] += 10;

            }

            for (int i = 0; i < numbers.Length; i++)
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

        #endregion

    }
}
      