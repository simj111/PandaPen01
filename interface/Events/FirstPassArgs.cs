using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void FirstPassHandler(IAnimalModel source, FirstPassArgs args);

    public class FirstPassArgs : EventArgs
	{
        private string _imagesource;

        public string imagesource
        {
            get
            {
                return _imagesource;
            }
        }

        private double[] _values;
        public double[] values
        {
            get
            {
                return _values;
            }
        }



        public FirstPassArgs(string imagesource, double[] values)
        {
            _imagesource = imagesource;
            _values = values;
        }
	
}
}
