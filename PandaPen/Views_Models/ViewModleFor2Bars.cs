using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;
using Interfaces;
using System.Windows.Forms;namespace PandaPen.Views_Models
{
  public  class ViewModleFor2Bars : IViewModel
  {

        private double[] Number01 = new double[3];
 
        private Form VF = null;


        public ViewModleFor2Bars(Form TheForm)
        {
            VF = TheForm;
        }

        public void ConvertResultsFromCalc1(ICalculate source, PassCalcResultsArgs args)
        {
            if (args.CalculatorID == (VF as View2Bars).name)
            {
                for (int i = 0; i < args.values.Length; i++)
                {

                    Number01[i] = args.values[i];
                }


                for (int i = 0; i < args.values.Length; i++)
                {

                    if (Number01[i] >= 100)
                    {
                        Number01[i] = 99;
                    }

                    else if (Number01[i] <= 0)
                    {
                        Number01[i] = 1;
                    }
                }
            }
            SendResults();
        }


        public void Subscribe(IAnimalModel Animal, ICalculate Calculate)
        {
            Animal.fPass += new FirstPassHandler(ReciveFirstInput);
            Calculate.resPass += new PassCalcResultsHandler(ConvertResultsFromCalc1);
        }

        public void ReciveFirstInput(IAnimalModel source, FirstPassArgs args)
        {
            for (int i = 0; i < args.values.Length; i++)
            {

                Number01[i] = args.values[i];
            }

            string imageName = args.imagesource;

            for (int i = 0; i < args.values.Length; i++)
            {

                if (Number01[i] > 100)
                {
                    Number01[i] = 99;
                }
                else if (Number01[i] < 0)
                {
                    Number01[i] = 0;
                }
            }

            SendResults();
            if (imageName == "GoldFish2Bars")
            {
                (VF as View2Bars).animalPicBox.Image = PandaPen.Properties.Resources.fishpic;
            }
        }


        public void SendResults()
        {
            (VF  as View2Bars).hungryBar.Value = Convert.ToInt32(Number01[0]);
            (VF as View2Bars).oxygenBar.Value = Convert.ToInt32(Number01[1]);
            (VF as View2Bars).happinessBar.Value = Convert.ToInt32(Number01[2]);  
        }


        public double CheckHappiness()
        {
            throw new NotImplementedException();
        }
  }
}
