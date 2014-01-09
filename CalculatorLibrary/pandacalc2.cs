using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Interfaces.Events;

namespace CalculatorLibrary
{


    public class pandacalc2 : ICalculate
    {
        #region DataMembers
        double[] answers;
        public event FullHappinessHandler happiness;
        public event PassCalcResultsHandler resPass;
        public string InvidualCalulatorValue;
        private string _imageName = "Panda";
        #endregion

        public void InitialPassIn(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
        }
       
        public void CalculateValues(double[] numbers, string Operations)
        {
            if (Operations == "Eat")
            {
                numbers[0] = numbers[0] + 2;
                numbers[1] = numbers[1] + 3;
                numbers[2] = numbers[2] - 2;

            }

            else if (Operations == "Sleep")
            {

                numbers[0] -= 5;
                numbers[1] += 6;
                numbers[2] -= 2;

            }

            else if (Operations == "Exercise")
            {
                numbers[0] -= 5;
                numbers[1] -= 7;
                numbers[2] += 3;

            }

            else if (Operations == "Decrease")
            {
                numbers[0] -= 4;
                numbers[1] -= 4;
                numbers[2] -= 4;
            }

            answers = numbers;
            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalulatorValue);
            resPass(this, information);
        }

        public void CalculateHappines(double[] numbers)
        {
            if (numbers[0] >= 50 && numbers[1] >= 50 && numbers[2] >= 50)
            {
                numbers[3] = numbers[3] + 11;
            }
            answers = numbers;
        }

        public double[] Results()
        {
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] > 100)
                {
                    answers[i] = 100;
                }
                else if (answers[i] < 0)
                {
                    answers[i] = 0;
                }

                if (answers[3] == 100)
                {
                    FullHappinessArgs Happiness = new FullHappinessArgs("HappinessisfullPanda");
                    answers[3] = 0;
                    happiness(this, Happiness);

                }

            }
            return answers;
        }

    }
}
