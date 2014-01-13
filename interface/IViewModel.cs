using System;
using Interfaces.Events;

namespace Interfaces
{
   public interface IViewModel
    {
           void Subscribe(IAnimalModel Animal, ICalculate Calculate);
           void ReciveFirstInput(IAnimalModel source, FirstPassArgs args);
           void SendResults();
           void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args);
           void LastMove(ICalculate calc, FullHappinessArgs args);
           

    }
}
