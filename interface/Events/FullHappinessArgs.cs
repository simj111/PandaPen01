using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void FullHappinessHandler(ICalculate calc, FullHappinessArgs args);

    public class FullHappinessArgs
    {
        private string _happiness;
        public string happiness
        {     get   
             {
                return _happiness;
             }
        }

        public FullHappinessArgs(string happiness)
        {
            _happiness = happiness;
           
        }

 

    }
}
