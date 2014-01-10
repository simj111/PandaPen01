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

   public interface IAnimalModel
    {
       event FirstPassHandler fPass;

       IButtonManager GetButtonsForSubscibe();

       ICalculate Getcalc();

       string Name(string _imageName, double ID);

       void PassinInatial(IButtonManager mybuttonmanager, ICalculate calculator, int ID);

       void FirstPassSetUP();

       void Calculate(string Animal);     

       void decTimer_Tick(object sender, EventArgs e);

       void happinessTimer_Tick(object sender, EventArgs e);

       void KillTimers();

    }
}
