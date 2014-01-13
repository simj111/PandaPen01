using System;

namespace Interfaces.Events
{
    public delegate void FullHappinessHandler(ICalculate calc, FullHappinessArgs args);

    public class FullHappinessArgs
    {
        private string _CalcuatorID;
        public string CalculatorID
        {
            get
            {
                return _CalcuatorID;
            }
        }

        private string _happiness;
        public string happiness
        {     get   
             {
                return _happiness;
             }
        }

        public FullHappinessArgs(string happiness, string CalculatorID )
        {
            _CalcuatorID = CalculatorID;
            _happiness = happiness;
           
        }

 

    }
}
