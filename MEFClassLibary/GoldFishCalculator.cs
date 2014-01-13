using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Text;
using Interfaces;
using Interfaces.Events;


namespace MEFClassLibary
{
    /// <summary>
    /// This is the GoldFishCalator and is used to Calcualte the gold fish valuse use the ICalculate Interface.
    /// </summary>
    
      [Export (typeof(ICalculate))]
      [ExportMetadata("description", "GoldFish2Bars")]
      [ExportMetadata("CalDescription", "GoldFish2Bars_Easy")]

    public class GoldFishCalculator : ICalculate
    {
        /// <summary>
        /// Data Members Contins 
        /// The EventPassCaclcResult Handler which pass the vasluse to the view Module through the event Handler
        /// a double array answer which is used to cacluate all bar valuses.
        /// The Imagename of the gold fish and an InvidualCalulatorValue passed in fomr the modle
        /// </summary>

        #region DataMembers
        public event PassCalcResultsHandler resPass;
        double[] answers;
        public string _imageName = "GoldFish2Bars";
        private string InvidualCalulatorValue;
        public event FullHappinessHandler happiness;
        #endregion DataMembers

        /// <summary>
        /// Constructor create A value to check the events to see if the correct Animal modle is reciving the events by passing in a number of what module it is and adding that to the string 
        /// the image name is Constant for all Modles, Bars and views of this type .
        /// </summary>
        /// <param name="IDvalue"></param>



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

        public string InitialPassIn(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
            return InvidualCalulatorValue;
        }

        public void CalculateValues(double[] numbers, string Operations)
        {
            if (Operations == "Button1")
            {
                numbers[0] = numbers[0] + 15;
                numbers[1] = numbers[1] + 5;
            }

            else if (Operations == "Button2")
            {
                numbers[0] = numbers[0] + 15;
                numbers[1] = numbers[1] + 5;
            }
            else if (Operations == "Decrease")
            {
                numbers[0] -= 5;
                numbers[1] -= 5;
            }
            answers = numbers;
        }

        /// <summary>
        /// Calulates any Change to the Happines Bar on tick Events
        /// </summary>
        /// <param name="numbers"></param>

        public void CalculateHappines(double[] numbers)
        {
            if (numbers[0] >= 50 && numbers[1] >= 50)
            {
                numbers[2] = numbers[2] + 30;
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

                if (answers[2] == 100)
                {
                    FullHappinessArgs Happiness = new FullHappinessArgs("Happinessisfull", InvidualCalulatorValue);
                    
                    happiness(this, Happiness);
                }
            }
            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalulatorValue);
            resPass(this, information);
            return answers;
        }

        #endregion Methods


    }
}
