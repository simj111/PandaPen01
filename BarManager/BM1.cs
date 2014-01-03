using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;


namespace BarManager
{
    public class BM1 : IBarManager
    {
        IAnimalModle Animal;

        public void Subscribe(IViewEvents f)
        {
            f.btnPress += new ButtonPressEventHandler(CheckIfValid);
        }

        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {
            if (args.information == "Eat")
            {
                PassOutCalucaltion("Test01");
            }
            else if (args.information == "Sleep")
            {
                PassOutCalucaltion("Test01");
            }
            else if (args.information == "Exercise")
            {
                PassOutCalucaltion("Test01");
            }
        }
        public void PassOutCalucaltion(string Clacualtion)
        {
            if (Animal == null)
            {

            }

            Animal.Calculate(Clacualtion);

        }


        public void ConnectANIMAL(IAnimalModle LINKEDANIMAL)
        {
            Animal = LINKEDANIMAL;
        }



    }
}
