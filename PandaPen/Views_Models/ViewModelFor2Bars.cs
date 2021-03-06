﻿using System;
using System.Diagnostics;
using Interfaces.Events;
using Interfaces;
using System.Windows.Forms;

namespace PandaPen.Views_Models
{
  public  class ViewModelFor2Bars : IViewModel
  {

        private double[] Number01 = new double[3];
        private string formName;

        private Form VF = null;

        public ViewModelFor2Bars(Form TheForm)
        {
            VF = TheForm;
        }

        public void Subscribe(IAnimalModel Animal, ICalculate Calculate)
        {
            Animal.fPass += new FirstPassHandler(ReciveFirstInput);
            Calculate.resPass += new PassCalcResultsHandler(ConvertResultsFromCalc);
            Calculate.happiness += new FullHappinessHandler(LastMove);
        }

        public void ReciveFirstInput(IAnimalModel source, FirstPassArgs args)
        {
            for (int i = 0; i < args.values.Length; i++)
            {

                Number01[i] = args.values[i];
            }

            string imageName = args.imagesource;


            SendResults();

            if (imageName == "GoldFish2Bars")
            {
                (VF as View2Bars).animalPicBox.Image = PandaPen.Properties.Resources.fishpic;
            }
        }

        public void SendResults()
        {
            (VF as View2Bars).hungryBar.Value = Convert.ToInt32(Number01[0]);
            (VF as View2Bars).oxygenBar.Value = Convert.ToInt32(Number01[1]);
            (VF as View2Bars).happinessBar.Value = Convert.ToInt32(Number01[2]);
        }

        public void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args)
        {
            formName = (VF as IAnimalViews).fName();

            if (args.CalculatorID == formName)
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
                        Number01[i] = 1;
                    }
                }
            }
            SendResults();
        }

        public void LastMove(ICalculate calc, FullHappinessArgs args)
        {
            if (args.CalculatorID == formName)
            {
                Number01[2] = 100;
                SendResults();
                (VF as View2Bars).fBtn.Enabled = false;
                (VF as View2Bars).cleanBtn.Enabled = false;
            }
        }
  }
}
