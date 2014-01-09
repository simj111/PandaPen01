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
    [Export(typeof(ICalculate))]
    [ExportMetadata("description", "Panda")]
    [ExportMetadata("CalDescription", "Panda_Easy")]


    public class pandacalc2 : ICalculate
    {
        #region DataMembers
        double[] answers;
        public event FullHappinessHandler happiness;
        public event PassCalcResultsHandler resPass;
        public string InvidualCalulatorValue;
        private string _imageName = "Panda";
        #endregion

        public string InitialPassIn(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
            return InvidualCalulatorValue;
        }
       
        public void CalculateValues(double[] numbers, string Operations)
        {
            if (Operations == "Button1")
            {
                numbers[0] = numbers[0] + 4;
                numbers[1] = numbers[1] + 2;
                numbers[2] = numbers[2] - 1;


            }

            else if (Operations == "Button2")
            {

                numbers[0] -= 2;
                numbers[1] += 4;
                numbers[2] -= 1;
            }

            else if (Operations == "Button3")
            {
                numbers[0] -= 6;
                numbers[1] -= 6;
                numbers[2] += 10;

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
                    FullHappinessArgs Happiness = new FullHappinessArgs("HappinessisfullPanda", InvidualCalulatorValue);
                    answers[3] = 0;
                    happiness(this, Happiness);

                }

            }
            return answers;
        }

    }
}
