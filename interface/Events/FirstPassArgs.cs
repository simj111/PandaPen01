using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void FirstPassHandler(string imagesource, double HBarValue, double EBarValue, double FBarValue, FirstPassArgs args);

    class FirstPassArgs : EventArgs
	{
        public string _information;

        public string information
        {
            get
            {
                return _information;
            }
        }
	}
}
