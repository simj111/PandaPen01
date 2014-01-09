using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace AnimalModel
{
    
      [Export(typeof(IAnimalModle))]
      [ExportMetadata("description", "GoldFish2Bars")]
      
    

    
   public class GoldFish : IAnimalModle
    {
        /// <summary>
        /// The Data Members Contain string and doubles The Indvduul name is the specif of the object passed out to the BarMangers.
        /// The Doubles Contain Invidual BarVaules and are the Intial Valuse.
        /// The Events are the FristPassHandler is used to send out the Intial values when the system is Constrcuted
        /// </summary>
          private string IDVIDUALName;
          public string _imageName = "GoldFish2Bars";
          private double _Happinness = 1;
          private double _Hunger = 5;
          private double _OxygenLevel = 60;
          double[] number;
          public IButtonManager buttonmanager;
          public ICalculate Calculator;


        public Timer decTimer;
        public Timer happinessTimer;

          

       public event FirstPassHandler fPass;

      
        /// <summary>
        /// Is the Consructor for Panda it is used to transfer the Aninal its BarManger And Calulator
        /// Connect the Animal to its BarManger
        /// </summary>
        /// <param name="mybuttonmanager"></param>
        /// <param name="calculator"></param>
        /// <param name="ID"></param>
        /// 
        /// 
        /// 


       public void PassinInatial(IButtonManager mybuttonmanager, ICalculate calculator, int ID)
        {
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

            buttonmanager = mybuttonmanager;
            Name(_imageName, ID);
            mybuttonmanager.ConnectANIMAL(this, IDVIDUALName);
            Calculator = calculator;
            number = new double[3] { _Hunger, _OxygenLevel, _Happinness };

        }


        /// <summary>
        /// Frist Pass Set UP is called in the Controler to pass the Inital star up Variables
        /// </summary>

        public void FristPassSetUP()
        {


            FirstPassArgs args = new FirstPassArgs(_imageName, number);
           
            fPass(this, args);
        }
        public void KillTimers()
        {
            happinessTimer.Enabled = false;
            decTimer.Enabled = false;
        }

        /// <summary>
        /// Is Used in the controler to Get the Bars.
        /// </summary>
        /// <returns></returns>

        public IButtonManager GetButtonsForSubscibe()
        {
      
            return buttonmanager;
        }

        /// <summary>
        /// used to set the indivual name of the class which is used to Generate specif Events
        /// </summary>
        /// <param name="_imageName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>

       
       public string Name(string _imageName, double ID)
        {
                

               IDVIDUALName = _imageName + ID.ToString();
               return IDVIDUALName;
        }

        /// <summary>
        /// Pass in the valuses for the Calulators.
        /// </summary>
        /// <param name="Operations"></param>
        public void Calculate(string Operations)
        {
            
            Calculator.CalculateValues(number, Operations);
            number = Calculator.Results(); 

            
        }




        public ICalculate Getcalc()
        {
            return Calculator;

        }


        public void decTimer_Tick(object sender, EventArgs e)
        {
            Calculator.CalculateValues(number, "Decrease");
            number = Calculator.Results();
        }

        public void happinessTimer_Tick(object sender, EventArgs e)
        {
            Calculator.CalculateHappines(number);
            number = Calculator.Results();
        }
    }
    }

