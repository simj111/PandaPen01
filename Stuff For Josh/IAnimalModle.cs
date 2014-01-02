using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using interfaces.Events;

namespace interfaces.Interface
{

   public interface IAnimalModle
    {
       void Subscribe(string eventType);
        void informationHandler(IAttempt1Interface obj, ButtonPressEventArgs args);

    }
}
