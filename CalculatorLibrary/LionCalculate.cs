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
    [Export(typeof(ICalculate))]
    [ExportMetadata("description", "Lion")]
    [ExportMetadata("CalDescription", "Lion_Easy")]
   

    public class LionCalculate : ICalculate
    {
        #region DataMembers
        double[] answers;
        public event PassCalcResultsHandler resPass;
        public string InvidualCalulatorValue;
        private string _imageName = "Lion";
        public event FullHappinessHandler happiness;
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
        /// 

        public string InitialPassIn(int IDvalue)
        {
           InvidualCalulatorValue = _imageName + IDvalue.ToString();
            return InvidualCalulatorValue;
        }

        public void CalculateValues(double[] numbers,string Operations)

        {
            if (Operations == "Button1")
            {
                numbers[0] = numbers[0] + 15;
                numbers[1]  = numbers[1] + 5;
                numbers[2] = numbers[2] - 10;
              
            }

            else if (Operations == "Button2")
            {
              
                numbers[0] -= 10;
                numbers[1] += 15;
                numbers[2] -= 5;
                
            }

            else if (Operations == "Button3")
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

          

            answers = numbers;
           
        }

        public void CalculateHappines(double[] numbers)
        {
            if (numbers[0] >= 50 && numbers[1] >= 50 && numbers[2] >= 50)
            {
                numbers[3] = numbers[3] + 20;
            }
            answers = numbers;
        }


        /// <summary>
        /// Returns results to the relavant Animal modle for this caclotor when called
        /// </summary>
        /// <returns></returns>
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
                    FullHappinessArgs Happiness = new FullHappinessArgs("Happinessisfull", InvidualCalulatorValue);
                    
                    happiness(this, Happiness);
                }
            }
            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalulatorValue);
            resPass(this, information);
            return answers;
        }

        #endregion






      
    }
}

    

