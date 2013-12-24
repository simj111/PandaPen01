using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void PassCalcResultsHandler(double HBarValue, double EBarValue, double FBarValue, PassCalcResultsArgs args);

    public class PassCalcResultsArgs : EventArgs
	{
        private string _information;

         public string information
        {
            get 
            {
                return _information;
            }
        }

        public PassCalcResultsArgs(string information)
        {
            _information = information;
        }
	}
}
