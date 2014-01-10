using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;

namespace Interfaces
{
	public interface ICalculate
	{  
        event FullHappinessHandler happiness;

        event PassCalcResultsHandler resPass;

        string InitialPassIn(int IDvalue);

        void CalculateValues(double[] numbers, string Operations);

        void CalculateHappines(double[] numbers);

        double[] Results();
       
	}
}
