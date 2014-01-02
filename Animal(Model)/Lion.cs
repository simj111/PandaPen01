using System;
using Interfaces;
using Interfaces.Events;

namespace AnimalModel
{
   public class Lion : IAnimalModle
    {
        public IBarManager barmanager;
        public event FirstPassHandler fPass;
        private string _imageName = "Lion";
        private double _inHBarVal = 5;
        private double _inEBarVal = 60;
        private double _inFBarVal = 75;
        private double _happinessBarVal = 0;
        
        
        public Lion(IBarManager myBarManager, ICalculate calculator)
        {
            barmanager = myBarManager;
            
        }

        public IBarManager bars()
        {
      
            return barmanager;
        }


        public string Name()
        {
            throw new NotImplementedException();
        }

        public void Calculate()
        {
            throw new NotImplementedException();
        }

        public void GetPicture()
        {
            throw new NotImplementedException();
        }


        public void FristPassSetUP()
        {
            throw new NotImplementedException();
        }
    }
}
