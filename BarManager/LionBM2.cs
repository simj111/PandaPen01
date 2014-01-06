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
    {   int Number = 0;
        string InvidID;
        IAnimalModle Animal;

        public void Subscribe(IThreeBarViewEvents f)
        {
            f.btnPress += new ButtonPressEventHandler(CheckIfValid);
        }

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


        public void  ConnectANIMAL(IAnimalModle LINKEDANIMAL, string Name)
        {
            Animal = LINKEDANIMAL;
            InvidID = Name;
        }



    }
}

    

