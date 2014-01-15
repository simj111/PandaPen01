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
            
            

            Application.EnableVisualStyles();

            DefaultView first = null;

            if (first == null)
            {
                first = new DefaultView();
                Controller ctrl = new Controller(first);
            }

            

            Application.Run(first);
        }
    }
}
