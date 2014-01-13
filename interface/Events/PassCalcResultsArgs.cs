using System;

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

        private string _CalcuatorID;
        public string CalculatorID
        {
             get
            {
            return _CalcuatorID;
            }
        }

        public PassCalcResultsArgs(double[] values, string CalculatorID)
        {
            _values = values;
            _CalcuatorID = CalculatorID;

        }
    }
}
	

