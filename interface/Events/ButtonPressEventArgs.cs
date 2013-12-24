using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interfaces.Events
{
    public delegate void ButtonPressEventHandler(System.Windows.Forms.Button source, ButtonPressEventArgs args);

    public class ButtonPressEventArgs : EventArgs
	{
        private string _information;

        public string information
        {
            get 
            {
                return _information;
            }
        }

        public ButtonPressEventArgs(string information)
        {
            _information = information;
        }


	}
}
