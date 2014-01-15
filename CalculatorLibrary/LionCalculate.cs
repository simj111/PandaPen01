using System;
using Interfaces;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Interfaces.Events;

namespace CalculatorLibrary
{
    
    [Export(typeof(ICalculate))]
    [ExportMetadata("AnimalType", "Lion")]
    [ExportMetadata("CalDescription", "Lion_Easy")]
   
    /// <summary>
    /// The calculator classes are used to perform calculations on the animals values and return those values.
    /// </summary>
    public class LionCalculate : ICalculate
    {
        #region DataMembers
        private double[] answers; //This array of double's is used to store the answers after calculations have been made.
        private string InvidualCalculatorValue; //This is used to give the calculator a unique ID that can be associated with an animal.
        private string _imageName = "Lion"; //This is used to say which type of animal this calculator will be used for.

        //These events are meant to trigger when happiness has reached 100, and when results are ready to be passed out.
        public event PassCalcResultsHandler resPass;
        public event FullHappinessHandler happiness;
        #endregion

        #region Methods

        /// <summary>
        /// This method is used to combine the ID value passed in, and add it to the name of the animal type the calculator is associated to.
        /// It then returns this combination as IndividualCalculatorValue e.g. "Lion0".
        /// </summary>
        public string InitialPassIn(int IDvalue)
        {
           InvidualCalculatorValue = _imageName + IDvalue.ToString();
            return InvidualCalculatorValue;
        }

        /// <summary>
        /// This method is where the calculations actually happen and where the values of the associated animals are affected.
        /// </summary>
        /// <param name="numbers">This is the values of the animal associated to the calculator</param>
        /// <param name="Operations">This is a string of what it is asking the calculator to do e.g. "Button3"</param>
        public void CalculateValues(double[] numbers, string Operations)
        {
            //This checks if the button that has been pressed contains has passed through a string of "Button1".
            //Button1 represents the "Eat" button of the associated animal of this calculator, so as such the hungry value and energy value rise, but the fitness value decreases.
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

            //This reaches this if statement when the animals decrease timer has ticked and makes the non happiness values decrease by 2.
            else if (Operations == "Decrease")
            {
                numbers[0] -= 2;
                numbers[1] -= 2;
                numbers[2] -= 2;
            }

            //This makes the local answers array contain the values of the numbers array, which were passed in when this method was called.
            answers = numbers;          
        }

        /// <summary>
        /// This method is called every time the associated animal's happinessTimer has ticked.
        /// </summary>
        public void CalculateHappiness(double[] numbers)
        {
            //If the non happiness values are all above 50 then it will make the happiness value rise by 21.
            //This will do it every time the happiness timer ticks and these values are above 50.
            if (numbers[0] >= 50 && numbers[1] >= 50 && numbers[2] >= 50)
            {
                numbers[3] = numbers[3] + 20;
            }
            answers = numbers;
        }


        /// <summary>
        /// This method checks if any of the values are above 100, or below 0. This needs to happen because the progress bars can only deal with numbers within this range.
        /// It also checks if the happiness value is 100, if it is it will then fire off the FullHappinessArgs event.
        /// It fires off the event to pass on the calculation results.
        /// </summary>
        /// <returns>Returns answer, which is an array of all the animals current values</returns>
        public double[] Results()
        {
            //This for loop makes the program check through every value in the answers array and change the value if they are above 100, or below 0.
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

                //This checks if happiness is equal to 100
                if (answers[3] == 100)
                {
                    FullHappinessArgs Happiness = new FullHappinessArgs("HappinessisfullPanda", InvidualCalculatorValue);
                    answers[3] = 99;
                    happiness(this, Happiness); //Fires off the happiness FullHappinessHandler.
                }
            }

            //This event fires off the event which passes out the current animal values
            PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalculatorValue);
            resPass(this, information);

            //Returns the array answers.
            return answers;
        }

        #endregion






      
    }
}

    

