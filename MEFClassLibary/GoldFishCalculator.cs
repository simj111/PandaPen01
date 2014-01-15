using System;
using System.ComponentModel.Composition;
using Interfaces;
using Interfaces.Events;


namespace MEFClassLibary
{
    /// <summary>
    /// This is the GoldFishCalculator and is used to Calculate the gold fish values use the ICalculate Interface.
    /// </summary>
    
      [Export (typeof(ICalculate))]
      [ExportMetadata("AnimalType", "GoldFish2Bars")]
      [ExportMetadata("CalDescription", "GoldFish2Bars_Easy")]

    public class GoldFishCalculator : ICalculate
    {
        /// <summary>
        /// Data Members Containers 
        /// The EventPassCaclcResult Handler which pass the values to the view model through the event Handler
        /// a double array answer which is used to caclulate all bar values.
        /// The Imagename of the gold fish and an InvidualCalulatorValue passed in from the model
        /// </summary>

        #region DataMembers
        private double[] answers;
        private string _imageName = "GoldFish2Bars";
        private string InvidualCalulatorValue;

        public event PassCalcResultsHandler resPass;
        public event FullHappinessHandler happiness;
        #endregion DataMembers

        /// <summary>
        /// Constructor create A value to check the events to see if the correct Animal model is recieving the events by passing in a number of what model it is and adding that to the string 
        /// the image name is Constant for all Models, Bars and views of this type .
        /// </summary>
        /// <param name="IDvalue"></param>



        #region Methods

        /// <summary>
        /// Contians the Methods CalculateValues  which calculates the values based on the string passed in so it know what Operation to carry out
        /// Contains the Method Calculate Happines which Calculates the Happnines bar if a tick event has been fired.
        /// </summary>
        /// <param name="IDvalue"></param>

        /// <summary>
        /// Calculate Values pass in the values from Animal when it called as well as the string which tell it what opereation it should prefrom inside the statement
        /// This Method Also passes out the Events and number to the View Models and then these are Updated.
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
        /// Calculates any Change to the Happiness Bar on tick Events
        /// </summary>
        /// <param name="numbers"></param>

        public void CalculateHappiness(double[] numbers)
        {
            if (numbers[0] >= 50 && numbers[1] >= 50)
            {
                numbers[2] = numbers[2] + 11;
            }
            answers = numbers;
        }

        /// <summary>
        /// Returns results to the relavant Animal model for this calculator when called
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
             }
                if (answers[2] == 100)
                {
                    FullHappinessArgs Happiness = new FullHappinessArgs("Happinessisfull", InvidualCalulatorValue);
                    answers[2] = 100;
                    happiness(this, Happiness);
                }
           
            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalulatorValue);
            resPass(this, information);
            return answers;
        }

        #endregion Methods


    }
}
