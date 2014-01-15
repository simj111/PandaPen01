using System;
using System.ComponentModel.Composition;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace AnimalModel
{

    [Export(typeof(IAnimalModel))]
    [ExportMetadata("AnimalType", "Lion")]
 


   public class Lion : IAnimalModel
    {
        /// <summary>
        /// The INDIVIDUALName string is the specific name of the object passed out to the ButtonManager.
        /// The doubles contain invidual values for the bars that will be associated with the animal. They are the animal initial values.
        /// The Calculator and buttonmanager objects are used to hear and respond to events.
        /// The FirstPassHandler event is used to send out the initial values when the system is constrcuted.
        /// Contains a strings INDIVIDUALName which is an ID and an Image Name Lion
        /// </summary>
          private string INDIVIDUALName;
          private string _imageName = "Lion"; // This is used to store the type/name of an animal.
          private double _inHBarVal = 5;
          private double _inEBarVal = 60;
          private double _inFBarVal = 75;
          private double _happinessBarVal = 1;
          private double[] numbers;

          private ICalculate Calculator;
          private IButtonManager buttonmanager;

          //The following timers are used to trigger actions upon ticking.
          private Timer decTimer; //This is used to make the animals calculator decrease the animals values.
          private Timer happinessTimer; //This is used to trigger the animals calculator to check what the current happiness value is.

          public event FirstPassHandler fPass;


          /// <summary>
          /// This is used via the controller to retrieve the button manager associated with the animal.
          /// </summary>
          /// <returns></returns>
          public IButtonManager GetButtonsForSubscibe()
          {
              //The following line returns the associated button manager of this animal
              return buttonmanager;
          }

          /// <summary>
          /// This method is used simply to retrieve the current calculator associated with the animal.
          /// </summary>
          /// <returns>It returns the calculator associated with the animal.</returns>
          public ICalculate Getcalc()
          {
              return Calculator;
          }


          /// <summary>
          /// This is used to set the indivual name of the class which is used to generate specific events.
          /// </summary>
          /// <param name="_imageName"> this contains the name of the animal</param>
          /// <param name="ID">this contains the animal ID</param>
          /// <returns>Returns the name mixed with an ID e.g. "Lion0"</returns>
          public string Name(string _imageName, double ID)
          {
              INDIVIDUALName = _imageName + ID.ToString();
              return INDIVIDUALName;
          }

          /// <summary>
          /// This method is used to allow the animal to recieve a button manager, a calculator and an ID.
          /// </summary>
          /// <param name="mybuttonmanager">This is the button manager that the animal will be associated with</param>
          /// <param name="calculator">This is the calculator that the animal will use to perform actions which affect it's bar values</param>
          /// <param name="ID">This is the id of the animal</param>
          public void PassinInatial(IButtonManager mybuttonmanager, ICalculate calculator, int ID)
          {
              buttonmanager = mybuttonmanager; //This places the mybuttonmanager object into a local object.
              Name(_imageName, ID);
              buttonmanager.ConnectANIMAL(this, INDIVIDUALName); //This connects the animal to it's button manager
              Calculator = calculator;
              numbers = new double[4] { _inHBarVal, _inEBarVal, _inFBarVal, _happinessBarVal };
              //The above code stores the 4 bar values into an array of doubles. This is so that we can more easily use them e.g. numbers[0] instead of _inHBarVal

              //Decrease timer object properties
              decTimer = new Timer();
              decTimer.Enabled = true; //A timer is, by default, set to false when created so we needed to change it.
              decTimer.Interval = 3000; //Timers work on milleseconds and then tick. This one will "tick" every 3 seconds.
              this.decTimer.Tick += new System.EventHandler(this.decTimer_Tick);

              //Happiness timer object properties
              happinessTimer = new Timer();
              happinessTimer.Enabled = true;
              happinessTimer.Interval = 3000;
              this.happinessTimer.Tick += new System.EventHandler(this.happinessTimer_Tick); //This fires off the tick event and makes the program perform the happinessTimer_Tick every time the timer ticks.
          }

        /// <summary>
        /// This is called in the controller to pass the inital start up variables of the animal.
        /// </summary>
          public void FirstPassSetUP()
          {
            
            string imagename = _imageName;
            FirstPassArgs args = new FirstPassArgs(imagename, numbers);
            fPass(this, args); //This passes out the imagename of the animal and it's values via the fPass handler.
          }

        /// <summary>
        /// Pass in the values for the calculators to perform calculations on.
        /// </summary>
        /// <param name="Operations">This is defined by what button was pressed e.g. Button 1</param>
        public void Calculate(string Operations)
        {
            Calculator.CalculateValues(numbers, Operations);
            numbers = Calculator.Results(); //This code retrievs the new values of the animals bar values, after a calculation has been made.
        }

        /// <summary>
        /// This method is run everytime the decTimer ticks, in this animals example every 3 seconds.
        /// </summary>
        public void decTimer_Tick(object sender, EventArgs e)
        {
 	        Calculator.CalculateValues(numbers, "Decrease");
            numbers = Calculator.Results();
        }

        /// <summary>
        /// This method is run every 3 seconds to check if the happiness bar value needs to rise.
        /// </summary>
        public void happinessTimer_Tick(object sender, EventArgs e)
        {
 	        Calculator.CalculateHappiness(numbers);
            numbers = Calculator.Results();
        }

        /// <summary>
        /// This method is only run when the animal has the happiness value at 100. It is used to disable both of the timers.
        /// </summary>
       public void KillTimers()
       {
           happinessTimer.Enabled = false;
           decTimer.Enabled = false;
       }

       /// <summary>
       /// This method is used just to return the animal's name to anything that would need to require it.
       /// </summary>
       /// <returns></returns>
       public string ReturnName()
       {
           return INDIVIDUALName;
       }
    }
}
