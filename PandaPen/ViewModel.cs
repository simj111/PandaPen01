using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;

namespace PandaPen
{
    class ViewModel : IViewEvents
    {
        private double[] Number01 = new double[4];
        private View VF = null;
        public event PassCalcResultsHandler Resuts;
        public ViewModel( View TheForm)
        {
            VF = TheForm;
        }

        public void Subscribe(IAnimalModle Animal)
        {
            Animal.fPass += new FirstPassHandler(ReciveFirstInput);

        }

        public void Subscribe( ICalculate Calculate)
        {
            

        }

        public void ReciveFirstInput(IAnimalModle source, FirstPassArgs args)
        {
           
            for (int i = 0; i < args.values.Length; i++)
            {
            
                Number01[i] = args.values[i];
            }
            //double Alpha = args.values[0];
            //double Beta = args.values[1];
            //double Delta = args.values[2];
            //double Gamma = args.values[3];
            string imageName = args.imagesource;

            for (int i = 0; i < args.values.Length; i++)
            {
                if (Number01[i] < 0)
                {
                    Number01[i] = 0;
                }

                else if (Number01[i] > 100)
                {
                    Number01[1] = 100;
                } 
            }
            PassOutData();
           
           


            //if (Alpha < 0)
            //{
            //    Alpha = 0;
            //    VF.hungryBar.Value = Convert.ToInt32(Alpha);
            //}
            //else if (Alpha > 100)
            //{
            //    Alpha = 100;
            //    VF.hungryBar.Value = Convert.ToInt32(Alpha);
            //}
            //else if (Alpha >= 0 || Alpha <= 100)
            //{
            //    VF.hungryBar.Value = Convert.ToInt32(Alpha);
            //}


            //VF.energyBar.Value = Convert.ToInt32(Beta);
            //VF.fitnessBar.Value = Convert.ToInt32(Delta);
            //VF.happinessBar.Value = Convert.ToInt32(Gamma);




            if (imageName == "Panda")
            {
                VF.animalPicBox.Image = PandaPen.Properties.Resources.pandapic;
            }
            else if (imageName == "Lion")
            {
                VF.animalPicBox.Image = PandaPen.Properties.Resources.lionpic;
            }
           
            
        }

        public void PassOutData()
        {
            VF.hungryBar.Value = Convert.ToInt32(Number01[0]);
            VF.energyBar.Value = Convert.ToInt32(Number01[1]);
            VF.fitnessBar.Value = Convert.ToInt32(Number01[2]);
            VF.happinessBar.Value = Convert.ToInt32(Number01[3]);
            
        }


        public event ButtonPressEventHandler btnPress;

        public event AnimalTypeHandler selectAnimal;
    }
}
