using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace PandaPen
{
    class ViewModel : IViewModel
    {
        private double[] Number01 = new double[4];
        private double[] calculate = new double[4];
        private Form VF = null;


        public ViewModel( Form TheForm)
        {
            VF = TheForm;
        }

        public void Subscribe(IAnimalModel Animal, ICalculate Calculate)
        {
            Animal.fPass += new FirstPassHandler(ReciveFirstInput);
            Calculate.resPass += new PassCalcResultsHandler(ConvertResultsFromCalc);
            Calculate.happiness += new FullHappinessHandler(LastMove);

        }


        public void LastMove(ICalculate calc, FullHappinessArgs args)
        {
            if (args.CalculatorID == (VF as View).name)
            {
                Number01[3] = 100;
                SendResults();
                (VF as View).eBtn.Enabled = false;
                (VF as View).sBtn.Enabled = false;
                (VF as View).fBtn.Enabled = false;
                
            }
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
                    Number01[i] = 100;
                } 
                else if (Number01[i] < 0)
                {
                    Number01[i] = 0;
                }
            }

            SendResults();

            if (imageName == "Panda")
            {
                (VF as View).animalPicBox.Image = PandaPen.Properties.Resources.pandapic;
            }
            else if (imageName == "Lion")
            {
                (VF as View).animalPicBox.Image = PandaPen.Properties.Resources.lionpic;
            }
           
            
        }

        public void SendResults()
        {
            (VF as View).hungryBar.Value = Convert.ToInt32(Number01[0]);
            (VF as View).energyBar.Value = Convert.ToInt32(Number01[1]);
            (VF as View).fitnessBar.Value = Convert.ToInt32(Number01[2]);
            (VF as View).happinessBar.Value = Convert.ToInt32(Number01[3]);
            
        }

        public void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args)
        {
            if (args.CalculatorID == (VF as View).name)
            {
                for (int i = 0; i < args.values.Length; i++)
                {

                    Number01[i] = args.values[i];
                }


                for (int i = 0; i < args.values.Length; i++)
                {

                    if (Number01[i] >= 100)
                    {
                        Number01[i] = 100;
                    }

                    else if (Number01[i] <= 0)
                    {
                        Number01[i] = 0;
                    }
                }
            }

            SendResults();
        
        
  
        }


    }


}
