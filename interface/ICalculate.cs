using System;
using Interfaces.Events;

namespace Interfaces
{
    /// <summary>
    /// This interface will be used by any calculator and is used to perform calculations to properties of the animal using it.
    /// 
    /// Any class that uses the interface will need the following using statements:
    /// using Interfaces;
    /// using Interfaces.Events;
    /// 
    /// RULE: Happiness needs to reach 100 to win the game. 
    /// This is checked within the "Results" method.
    /// </summary>
	public interface ICalculate
	{  
        /// <summary>
        /// This event is used within the Results method and is fired off when the happiness value reaches 100. The happiness value will always be the last value of the array.
        /// </summary>
        event FullHappinessHandler happiness;

        /// <summary>
        /// This event is used within the CalculateValues method and is fired off at the end, when the results need to be passed on.
        /// </summary>
        event PassCalcResultsHandler resPass;

        /// <summary>
        /// In this method we have to add the IDvalue paramater to a string value and then return it. 
        /// It will require a name of an animal that the calculator wil be used for. e.g. "Panda"
        /// This is Crucial to the program.
        /// </summary>
        /// <param name="IDvalue"> This indicates a Unique ID of the calculator</param>
        /// <returns>It needs to return a string which is the combination of the animal name and the unique ID of the calculator</returns>
        string InitialPassIn(int IDvalue);
        
        /// <summary>
        /// This method recieves current values of the animal's properties (typically there are three properties e.g hunger, fitness and sleep) and a string representing the operation that the calculator must perform.
        /// These operations are only recognised as "Button1","Button2", "Button3", or "Decrease" and these affect the animals property values. 
        /// From these operations you must calculate how much each value will be affected when a certain button is pressed, or by how much they will be decreased over time. 
        /// For example if Button1 is pressed then all number values could be increased by 2.
        /// Another example would be if the "Decrease" operation is passed in then all values could be decreased by 4.
        /// The class will need it's own array of doubles("double[]") to store the numbers that have been affected.
        /// At the end of this method you need to fire off an argument and event, for those subscribed to recieve. PassCalcResultsArgs is needed.
        /// this is one possible example: PassCalcResultsArgs information = new PassCalcResultsArgs(answers, InvidualCalculatorValue);
        ///                               resPass(this, information);
        /// </summary>
        /// <param name="numbers">This paramater is the number values that are passed into the calculator from the animal. These are the properties of the animal, which are to be affected within this method.</param>
        /// <param name="Operations">This paramater is the operation that is being passed into the method. This will only ever be "Button1","Button2", "Button3", or "Decrease".</param>
        void CalculateValues(double[] numbers, string Operations);

        /// <summary>
        /// This method is called within the animal, through it's individual ticker. 
        /// It checks if the non happiness values are all at a certain value. e.g. if numbers[0], numbers[1], and numbers[2] are all above a specified number then the happiness value(numbers[3]) will increase by an amount you specify.
        /// Like CalculateValues you need to store the values from the numbers parameter within your own defined array of doubles. e.g. answers[]
        /// </summary>
        /// <param name="numbers">This paramater contains the values of the animals properties</param>
        void CalculateHappiness(double[] numbers);

        /// <summary>
        /// This method is used to return your array of doubles, that you have been storing the numbers in, to the animal.
        /// It also checks if the value of happiness is currently 100, if it is then it fires off the FullHappinessHandler event.
        /// For example FullHappinessArgs Happinessfull = new FullHappinessArgs("Happinessisfull", IndividualCalcYouDefined).
        ///                               happiness(this, Happinessfull);
        /// It would be prudent to add an aditional  for loop here to check any results passed out fall within 0 to 100. 
        /// This is due to progress bars only working within this range. e.g if over 100 make value 100, and if it is under 0 then make the value 0.
        /// </summary>
        /// <returns>This needs to return the value of your defined array e.g. return answers </returns>
        double[] Results();
       
	}
}
