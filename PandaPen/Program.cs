using System;
using System.Collections.Generic;
using System.Linq;
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
            Form first = new DefaultView();
          //  Application.SetCompatibleTextRenderingDefault(false);
            Controller ctrl = new Controller(first);
            
            Application.Run(first);
        }
    }
}
