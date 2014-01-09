using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interfaces.Events
{
    public delegate void ButtonPressEventHandler(Form f, ButtonPressEventArgs args);

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

        private string _IniatilID;

        public string IniatilID
        {
            get
            {
                return _IniatilID;
            }
        }

        private int _ButtonNumber;
        public int ButtonNumber
        {
            get
            {
                return _ButtonNumber;
            }

        }
        

       
       
    

        public ButtonPressEventArgs(string information, string IniatilID, int ButtonNumber )
        {
            _information = information;
            _IniatilID = IniatilID;
            _ButtonNumber = ButtonNumber;
        }


	}
}
