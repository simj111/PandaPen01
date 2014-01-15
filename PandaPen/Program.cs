

using System;
using System.Windows.Forms;

namespace PandaPen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //Makes the windows form look nicer.

            //Create a blank default view.
            DefaultView first = null;

            //This will make it so that it will only run once at the start when first is null
            if (first == null)
            {
                first = new DefaultView();

                Controller ctrl = new Controller(first); //Creates a new controller, called ctrl, with the defaultview "first" passed into it's constructor
            }

            Application.Run(first); //runs the form.
        }
    }
}
