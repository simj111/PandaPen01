using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;

namespace Interfaces
{
   public interface IViewModel
    {
           void Subscribe(IAnimalModel Animal, ICalculate Calculate);
           void ReciveFirstInput(IAnimalModel source, FirstPassArgs args);
           void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args);
           void SendResults();
           void LastMove(ICalculate calc, FullHappinessArgs args);
           

    }
}
