using System;
using System.ComponentModel.Composition;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace AnimalModel
{
      [Export(typeof(IAnimalModel))]
      [ExportMetadata("AnimalType", "GoldFish2Bars")]

   public class GoldFish : IAnimalModel
    {
        /// <summary>
        /// The Data Members Contain string and doubles The Indivdual name is the specific of the object passed out to the ButtonManagers.
        /// The Doubles Contain Invidual BarValues and are the Intial Values.
        /// The Events are the FirstPassHandler is used to send out the Initial values when the system is Constructed
        /// </summary>
          private string INDIVIDUALName;
          private string _imageName = "GoldFish2Bars";
          private double _Happinness = 1;
          private double _Hunger = 5;
          private double _OxygenLevel = 60;
          private double[] number;

          private IButtonManager buttonmanager;
          private ICalculate Calculator;

          private Timer decTimer;
          private Timer happinessTimer;

          public event FirstPassHandler fPass;

          /// <summary>
          /// Is Used in the controller to Get the Bars.
          /// </summary>
          /// <returns></returns>
          public IButtonManager GetButtonsForSubscibe()
          {
              return buttonmanager;
          }

          public ICalculate Getcalc()
          {
              return Calculator;
          }

          /// <summary>
          /// used to set the individual name of the class which is used to Generate specific Events
          /// </summary>
          /// <param name="_imageName"></param>
          /// <param name="ID"></param>
          /// <returns></returns>
          public string Name(string _imageName, double ID)
          {
              INDIVIDUALName = _imageName + ID.ToString();
              return INDIVIDUALName;
          }

          public void PassinInatial(IButtonManager mybuttonmanager, ICalculate calculator, int ID)
          {
            buttonmanager = mybuttonmanager;
            Name(_imageName, ID);
            mybuttonmanager.ConnectANIMAL(this, INDIVIDUALName);
            Calculator = calculator;
            number = new double[3] { _Hunger, _OxygenLevel, _Happinness };
              
            //Decrease timer object properties
            decTimer = new Timer();
            decTimer.Enabled = true;
            decTimer.Interval = 1500;
            this.decTimer.Tick += new System.EventHandler(this.decTimer_Tick);

            //Happiness timer object properties
            happinessTimer = new Timer();
            happinessTimer.Enabled = true;
            happinessTimer.Interval = 1500;
            this.happinessTimer.Tick += new System.EventHandler(this.happinessTimer_Tick);

            
          }

        /// <summary>
        /// First Pass Set UP is called in the Controller to pass the Inititial start up Variables
        /// </summary>
        public void FirstPassSetUP()
        {
            string imagename = _imageName;
            FirstPassArgs args = new FirstPassArgs(imagename, number);
            fPass(this, args);
        }
        
        /// <summary>
        /// Pass in the values for the Calculators.
        /// </summary>
        /// <param name="Operations"></param>
        public void Calculate(string Operations)
        {
            Calculator.CalculateValues(number, Operations);
            number = Calculator.Results(); 
        }

        public void decTimer_Tick(object sender, EventArgs e)
        {
            Calculator.CalculateValues(number, "Decrease");
            number = Calculator.Results();
        }

        public void happinessTimer_Tick(object sender, EventArgs e)
        {
            Calculator.CalculateHappiness(number);
            number = Calculator.Results();
        }

        public void KillTimers()
        {
            happinessTimer.Enabled = false;
            decTimer.Enabled = false;
        }


        public string ReturnName()
        {
            return INDIVIDUALName;
        }
    }
    }

