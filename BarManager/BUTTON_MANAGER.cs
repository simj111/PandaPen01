using System;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;


namespace ButtonManager
{
    /// <summary>
    /// The Purpose of This Class is to Enterpret Events to see if its Particular Animal Should React
    /// </summary>

    public class BUTTON_MANAGER : IButtonManager
    {
        /// <summary>
        /// The Data Members Contain an Animal to store the Animal this Particular ButtonManager is Linked to
        /// The string IndividualID Contains a string Reference which of the Object which is stored in the Model so it can be used to determine if the model should react
        /// </summary>
        IAnimalModel Animal;
        public string IndividualID;

        /// <summary>
        /// This Method is used to Subscribe to the events this Particular Subscribe to Button Press Recieved from ButtonEventHandler and which are Generated in the view
        /// The Class for this Is currently called View
        /// </summary>
        /// <param name="f"></param>
        public void Subscribe(Form f)
        {
            (f as IAnimalViews).btnPress += new ButtonPressEventHandler(CheckIfValid);
        }

        /// <summary>
        /// This Methods Job is to Ensure that Any Events Recivied are Valid for the Specific Model.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>
        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {
            if (args.IniatilID == IndividualID)
            {

                if (args.information == "Button1")
                {
                    PassOutCalucaltion(args.information);
                }
                else if (args.information == "Button2")
                {
                    PassOutCalucaltion(args.information);
                }
                else if (args.information == "Button3")
                {
                    PassOutCalucaltion(args.information);
                }
            }
        }

        /// <summary>
        /// This Method is used to allow the Buttonmanger to Speak to its Specific animal Model 
        /// </summary>
        /// <param name="LINKEDANIMAL"></param>
        /// <param name="Name"></param>
        public void ConnectANIMAL(IAnimalModel LINKEDANIMAL, string Name)
        {
            Animal = LINKEDANIMAL;
            IndividualID = Name;
        }

        /// <summary>
        /// Pass Out Calculation type to the Animal Model which pass it out to the Calculator to ensure success
        /// </summary>
        /// <param name="Clacualtion"></param>
        public void PassOutCalucaltion(string Clacualtion)
        {
            Animal.Calculate(Clacualtion);
        }

       public void Unsubscribe(IAnimalViews f)
       {   Animal.KillTimers();   
           (f as IAnimalViews).btnPress -= new ButtonPressEventHandler(CheckIfValid);
                
       }
    }
}
