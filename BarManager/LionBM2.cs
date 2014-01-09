using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace BarManager
{
    public class  LionBM2 : IBarManager
    {   
        # region DataMebers
        /// <summary>
        /// Containts string which is the Invidual name of the  And the Animal Modle sot it can pass out ressults.
        /// Contains the anmal it is linked to.
        /// </summary>
       
        string InvidID;
        IAnimalModle Animal;


        #endregion

        #region Metods

        ///<summary>
        /// Contians Methods ConnectAnimal which are used to Link the Animal to its Calcuator so it can pass out what type of Calution is need to carry out
        /// Subscribes the Barmanger to Buttonpress Events so it can respond Acordingly.
        /// Check If Vaild which the events are passed into and checked to see if they are vallied
        /// they then pass out a string using the Pass Out CalucationMethod to the Animal so it can tell the specif Animal what it needs to do
        /// </summary>
        
        
        #endregion 

        /// <summary>
        /// Conecnts the Barmanger to its Animal.
        /// </summary>
        /// <param name="f"></param>
        /// 
        public void ConnectANIMAL(IAnimalModle LINKEDANIMAL, string Name)
        {
            Animal = LINKEDANIMAL;
            InvidID = Name;
        }

        /// <summary>
        /// Subscribes the Barmanger to the Button Presses.
        /// </summary>
        /// <param name="f"></param>
        public void Subscribe(Form f)

        {
            (f as IViewEvents).btnPress += new ButtonPressEventHandler(CheckIfValid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>
        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {

            if (args.information == "Eat" && args.IniatilID == InvidID)
            {
                PassOutCalucaltion(args.information);
            }
            else if (args.information == "Sleep" && args.IniatilID == InvidID)
            {
                PassOutCalucaltion(args.information);
            }
            else if (args.information == "Exercise" && args.IniatilID == InvidID)
            {
                PassOutCalucaltion(args.information);
            }
        
        }
        public void PassOutCalucaltion(string Clacualtion)
        {
           Animal.Calculate(Clacualtion);

        }


        public void Unsubscribe(Form f)
        {
            (f as IViewEvents).btnPress -= new ButtonPressEventHandler(CheckIfValid);

        }



    }
}

    

