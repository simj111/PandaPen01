using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;

namespace Interfaces
{

   public interface IAnimalModle
    {

       IBarManager Getbars();

       void PassinInatial(IBarManager myBarManager, ICalculate calculator, int ID);

       ICalculate Getcalc();

       string Name(string _imageName, double ID);

       void Calculate(string Animal);     
         
       event FirstPassHandler fPass;

       void FristPassSetUP();

       void decTimer_Tick(object sender, EventArgs e);

       void happinessTimer_Tick(object sender, EventArgs e);

    }
}
