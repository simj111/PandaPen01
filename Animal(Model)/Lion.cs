using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using BarManager;

namespace AnimalModel
{
   public class Lion : IAnimalModle
    {
        public IBarManager barmanager;
        public Lion(IBarManager myBarManager)
        {

            
        }

        public IBarManager bars()
        {
            IBarManager myBarManager = new BM1();
            barmanager = myBarManager;
            return barmanager;
        }
    }
}
