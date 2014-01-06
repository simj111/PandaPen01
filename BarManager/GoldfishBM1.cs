using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace BarManager
{
   public class GoldfishBM1 : IBarManager
    {
     
       IAnimalModle Animal;
       public string InvidID;
        public void Subscribe(Form f)

        {
            (f as ITWOEVENTS).btnPress += new ButtonPressEventHandler(CheckIfValid);
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

        public void PassOutCalucaltion(string Clacualtion)
        {
            Animal.Calculate(Clacualtion);
        }
        public void ConnectANIMAL(IAnimalModle LINKEDANIMAL, string Name)
        {
            Animal = LINKEDANIMAL;
            InvidID = Name;
        }
    }
}
