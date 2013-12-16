using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PandaPen
{
    class Controller
    {
        View _view = new View();
       
        public Controller()
        {
            Application.Run(_view);
        }



    }
}
