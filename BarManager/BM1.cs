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
        public void Subscribe(IViewEvents f)
        {
            f.btnPress += new ButtonPressEventHandler(CheckIfValid);
        }
        public void CheckIfValid(Form f, ButtonPressEventArgs args)
        {
            if (args.information == "Eat")
            {

            }
            else if (args.information == "Sleep")
            {

            }
            else if (args.information == "Exercise")
            {

            }
        }

    }
}
