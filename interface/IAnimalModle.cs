using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;

namespace Interfaces
{

   public interface IAnimalModle
    {

       IBarManager Getbars();
       ICalculate Getcalc();
       string Name(string _imageName, double ID);
       void Calculate(string Animal);              
       event FirstPassHandler fPass;
       void FristPassSetUP();

    }
}
