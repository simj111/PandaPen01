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
        private string _imageName = "GoldFish2Bars";
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

        /// <summary>
        /// Calulates any Change to the Happines Bar on tick Events
        /// </summary>
        /// <param name="numbers"></param>

        public void CalculateHappines(double[] numbers)
        {
            if (numbers[0] >= 50 && numbers[1] >= 50)
            {
                numbers[2] = numbers[2] + 11;
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
                    FullHappinessArgs Happiness = new FullHappinessArgs("Happinessisfull");
                    answers[3] = 0;
                    happiness(this, Happiness);

                }

            }
            return answers;
        }
        #endregion Methods


        public void InitialPassIn(int IDvalue)
        {
            InvidualCalulatorValue = _imageName + IDvalue.ToString();
        }
    }
}
