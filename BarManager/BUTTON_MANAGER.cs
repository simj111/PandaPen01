using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;


namespace ButtonManager
{
    /// <summary>
    /// The Purpouse of This Class is to Enterprate Events to see if its Particular Animal Should React
    /// </summary>

    public class BUTTON_MANAGER : IButtonManager
    {
        /// <summary>
        /// The Data Members Contain a Animal to store the Animal this Particular BarManger is Linked to
        /// The string InvidID Contains a string Reference which of the Object which is stored in the Modle so it can be used to deterem if the module should react]
        /// </summary>
        
        IAnimalModle Animal;
        public string InvidID;
        /// <summary>
        /// This Method is used to Subscribe to the events this Particullar Sucrbies to Button Press Recived from ButtonEventHandler and which are Genreated in the view
        /// The Class for this Is currently called View
        /// </summary>
        /// <param name="f"></param>
        public void Subscribe(Form f)
        {
            (f as IViewEvents).btnPress += new ButtonPressEventHandler(CheckIfValid);
        }
        /// <summary>
        /// This Methods Job is to Ensure that Any Events Recivied are Valid for the Specific Model.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>
        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {
            if (args.IniatilID == InvidID)
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
        /// Pass Out Calucation type to the Animal Modle which pass it out to the Calulator to ensure success
        /// </summary>
        /// <param name="Clacualtion"></param>
        public void PassOutCalucaltion(string Clacualtion)
        {
            Animal.Calculate(Clacualtion);
        }

        /// <summary>
        /// This Method is used to allow the Barmanger to Speak to its Specific animal Modle
        /// </summary>
        /// <param name="LINKEDANIMAL"></param>
        /// <param name="Name"></param>

       public void ConnectANIMAL(IAnimalModle LINKEDANIMAL, string Name)
        {
            Animal = LINKEDANIMAL;
            InvidID = Name;

        }


       public void Unsubscribe(Form f)
       {  
           (f as IViewEvents).btnPress -= new ButtonPressEventHandler(CheckIfValid);
           Animal.KillTimers();         
       }
    }
}
