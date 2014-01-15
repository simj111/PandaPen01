using System;
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

        private string _InitialID;

        public string InitialID
        {
            get
            {
                return _InitialID;
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
        

       
       
    

        public ButtonPressEventArgs(string information, string InitialID, int ButtonNumber )
        {
            _information = information;
            _InitialID = InitialID;
            _ButtonNumber = ButtonNumber;
        }


	}
}
