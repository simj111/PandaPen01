using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Text;
using Interfaces;
using Interfaces.Events;

namespace CalculatorLibrary
{
    /// <summary>
    /// This is the LionCalcutor and is used to Calcualte the gold fish valuse use the ICalculate Interface.
    /// </summary>

    

    public class LionCalculate : ICalculate
    {
        #region DataMembers
        double[] answers;
        public event PassCalcResultsHandler resPass;
        public string InvidualCalulatorValue;
        private string _imageName = "Lion";
        #endregion

        #region Constrcutor

        public void InitialPassIn(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Contians the Methods CalcualteValues  which acaultes the valuse bassed on the string passed in so it know what Operration to carry out
        /// Contains the Method Cacluate Happines which Calcuates the Happnines bar if a tick event has been fired.
        /// </summary>
        /// <param name="IDvalue"></param>

        /// <summary>
        /// Caculate Values pass in the values from Anima when it called as well as the string which tell it what opereation it should prefrom inside the statement
        /// This Method Also pass out the Events and number to the View Modles and then these are Updated.
        /// </summary>

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

            else if (Operations == "Decrease")
            {
                numbers[0] -= 2;
                numbers[1] -= 2;
                numbers[2] -= 2;
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
            if (numbers[0] >= 50 && numbers[1] >= 50 && numbers[2] >= 50)
            {
                numbers[3] = numbers[3] + 4;
            }
            answers = numbers;
        }


        /// <summary>
        /// Returns results to the relavant Animal modle for this caclotor when called
        /// </summary>
        /// <returns></returns>

        public double[] Results()
        {
            return answers;
        }
        #endregion

    }
}

    

