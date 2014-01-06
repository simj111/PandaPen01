using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;

namespace Interfaces
{
   public interface IViewModel
    {
           void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args);
           void Subscribe(IAnimalModle Animal, ICalculate Calculate);
           void ReciveFirstInput(IAnimalModle source, FirstPassArgs args);
           void SendResults();



    }
}
