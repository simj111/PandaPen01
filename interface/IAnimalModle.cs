using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;

namespace Interfaces
{

   public interface IAnimalModle
    {
       IBarManager bars();
       String Name();
       void Calculate();
       void GetPicture();
       event FirstPassHandler fPass();
       //stuff
       ///kkkk
       ////ppp
       ///l
    }
}
