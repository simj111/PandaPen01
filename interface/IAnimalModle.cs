using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Interfaces
{

   public interface IAnimalModle
    {
       IBarManager bars();
       String Name();
       void Calculate();
       void GetPicture();
    }
}
