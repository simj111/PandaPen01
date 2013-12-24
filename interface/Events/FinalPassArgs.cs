using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void FinalPassHandler(double source, FinalPassArgs args);
    public class FinalPassArgs : EventArgs
	{
         private string _information;

         public string information
        {
            get 
            {
                return _information;
            }
        }

        public FinalPassArgs(string information)
        {
            _information = information;
        }
	}
}
