using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;

namespace PandaPen
{
    class ViewModel : IViewModel
    {
        private double[] Number01 = new double[4];
        private double[] calculate = new double[4];
        private View VF = null;


        public ViewModel( View TheForm)
        {
            VF = TheForm;
        }

        public void Subscribe(IAnimalModle Animal, ICalculate Calculate)
        {
            Animal.fPass += new FirstPassHandler(ReciveFirstInput);
            Calculate.resPass += new PassCalcResultsHandler(ConvertResultsFromCalc);

        }


        public void ReciveFirstInput(IAnimalModle source, FirstPassArgs args)
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

            if (imageName == "Panda")
            {
                VF.animalPicBox.Image = PandaPen.Properties.Resources.pandapic;
            }
            else if (imageName == "Lion")
            {
                VF.animalPicBox.Image = PandaPen.Properties.Resources.lionpic;
            }
           
            
        }

        public void SendResults()
        {
            VF.hungryBar.Value = Convert.ToInt32(Number01[0]);
            VF.energyBar.Value = Convert.ToInt32(Number01[1]);
            VF.fitnessBar.Value = Convert.ToInt32(Number01[2]);
            VF.happinessBar.Value = Convert.ToInt32(Number01[3]);
            
        }

        public void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args)
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

            SendResults();
        }
    }
}
