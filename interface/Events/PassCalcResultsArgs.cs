using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void PassCalcResultsHandler(ICalculate source, PassCalcResultsArgs args);

    public class PassCalcResultsArgs : EventArgs
    {
        private double[] _values;
        public double[] values
        {
            get
            {
                return _values;
            }
        }

        public PassCalcResultsArgs(double[] values)
        {
            _values = values;
        }
    }
}
	

