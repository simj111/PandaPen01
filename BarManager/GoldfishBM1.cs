using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace BarManager
{

    /// <summary>
    /// This Class Is the GoldFish Barmanger Class It recives Events the BarMangerneeds
    /// </summary>
   public class GoldfishBM1 : IBarManager
    {
       /// <summary>
       /// Data Members Contaisn The Anima modle it is linked to#
       /// The Idvidual Id of that Animal Modle
       /// </summary>
             
      #region DataMembers
      IAnimalModle Animal;
      public string InvidID;   
      #endregion

       #region Methods
       /// <summary>
       /// The Methods In this area are Subsibe which Subscribes the Goldfish to its Button press Events
       /// </summary>
       /// <param name="f"></param>



      /// <summary>
      /// Conects the Animal to its Specfic Modle
      /// </summary>
       public void ConnectANIMAL(IAnimalModle LINKEDANIMAL, string Name)
      {
            Animal = LINKEDANIMAL;
            InvidID = Name;
      } 

       /// <summary>
       /// Subscribe the BarManget to Button Press Event System
       /// </summary>
       /// <param name="f"></param>
       public void Subscribe(Form f)
   
       {
           (f as IViewEvents).btnPress += new ButtonPressEventHandler(CheckIfValid);
        }

        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {
            if (args.information == "EatFishFood" && args.IniatilID == InvidID)
            {
                PassOutCalucaltion(args.information);
            }
            else if (args.information == "CleaningAir" && args.IniatilID == InvidID)
            {
                PassOutCalucaltion(args.information);
            }
        }
       /// <summary>
       /// Pass Out the string Calucation so the Animal can Calculate it
       /// </summary>
       /// <param name="Clacualtion"></param>

        public void PassOutCalucaltion(string Clacualtion)
        {
            Animal.Calculate(Clacualtion);
        }

        public void Unsubscribe(Form f)
        {
            (f as IViewEvents).btnPress -= new ButtonPressEventHandler(CheckIfValid);

        }

       #endregion  
    }
}
