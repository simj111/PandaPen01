using System;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;


namespace ButtonManager
{
    /// <summary>
    /// The purpose of this class is to interpret button press events and to check if its particular animal should react to those events.
    /// </summary>

    public class BUTTON_MANAGER : IButtonManager
    {
        /// <summary>
        /// The data members contain an animal to store the animal this particular buttonmanager is linked to.
        /// The string IndividualID is used to store a string reference of the ID of the animal associated with the button manager.
        /// </summary>
        IAnimalModel Animal;
        public string IndividualID;

        /// <summary>
        /// This method is used to subscribe to the button press event recieved from ButtonEventHandler. This is sent from the view.
        /// </summary>
        /// <param name="f"> This is simply the passed in form that the buttonpress will be coming from</param>
        public void Subscribe(Form f)
        {
            (f as IAnimalViews).btnPress += new ButtonPressEventHandler(CheckIfValid);
        }

        /// <summary>
        /// This methods job is to ensure that any events recivied are valid for the specific model.
        /// This is necessary as one view may only have 2 buttons, but another may have 3. 
        /// </summary>
    
        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {
            //This if statement checks if the passed in initialID matches the one associated with the button manager.
            //If it is then it will call the PassOutCalculation method and give it the information that it needs via the button press argument.
            if (args.InitialID == IndividualID)
            {
               PassOutCalculation(args.information);
            }
        }

        /// <summary>
        /// This method is used to associate the buttonmanger with a specific animal model that is given to it.
        /// </summary>
        public void ConnectANIMAL(IAnimalModel LINKEDANIMAL, string Name)
        {
            Animal = LINKEDANIMAL;
            IndividualID = Name;
        }

        /// <summary>
        /// This method tells the animal to perform its Calculate method. It passes out the string associated with the button, via "Calculation"
        /// </summary>
        /// <param name="Calculation">This parameter contains the string associated with a button press e.g. "Button1"</param>
        public void PassOutCalculation(string Calculation)
        {
            Animal.Calculate(Calculation);
        }

       /// <summary>
       /// This method is called once an associated animal's happiness bar has reached 100.
       /// It unsubscribes from the btnPress event and makes the animal run its "KillTimers" method.
       /// </summary>
       public void Unsubscribe(IAnimalViews f)
       {   Animal.KillTimers(); //Makes the animal deactivate it's timers.  
           (f as IAnimalViews).btnPress -= new ButtonPressEventHandler(CheckIfValid);
                
       }
    }
}
