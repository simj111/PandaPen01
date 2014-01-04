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
        public string INDIDUALName01;
        private double ID;
        
        public Lion(IBarManager myBarManager, ICalculate calculator, int ID)
        {
            barmanager = myBarManager;
            Name(_imageName, ID);
            myBarManager.ConnectANIMAL(this, INDIDUALName01);
        }

        public string Name(string _imageName, double ID)
        {

     
            INDIDUALName01 = _imageName + ID.ToString();
            return INDIDUALName01;
        }

        public IBarManager Getbars()
        {
      
            return barmanager;
        }       
       public void FristPassSetUP()
        {
            double[] numbers = new double[4] { _inHBarVal, _inEBarVal, _inFBarVal, _happinessBarVal };
            string imagename = _imageName;
            FirstPassArgs args = new FirstPassArgs(imagename, numbers);
            fPass(this, args);

        }


       
       public void Calculate(string Operations)
       {
           double[] numbers = new double[3] { _inHBarVal, _inEBarVal, _inFBarVal };
           int i = 0;
           i++;

       }

       public void GetPicture()
       {

       }
       
       
    }
}
