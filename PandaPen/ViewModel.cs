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
            double alpa = args.EBarValue;
            double Beta = args.FBarValue;
            double Delta = args.HBarValue;
            double Gamma = args.HapnninesBar;
            
            VF.energyBar.Value = Convert.ToInt32(alpa);
            VF.fitnessBar.Value = Convert.ToInt32(Beta);
            VF.hungryBar.Value = Convert.ToInt32(Delta);
            VF.happinessBar.Value = Convert.ToInt32(Gamma);
           
            
        }




        public event ButtonPressEventHandler btnPress;

        public event AnimalTypeHandler selectAnimal;
    }
}
