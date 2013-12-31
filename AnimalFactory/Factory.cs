using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using BarManager;
using AnimalModel;
using CalculatorLibrary;

namespace AnimalFactory
{
    public class Factory
    {
        public List<string> typeoflist = new List<string>();
        public List<IAnimalModle> animallist = new List<IAnimalModle>();

        public Factory()
        {
            FindTypes();
        }
        public void FindTypes()
        {
            typeoflist.Add("Panda");
            typeoflist.Add("Lion");
        }

        public void GeneratAnimals(string Animal)
        {
            
            if (typeoflist.Any(str => str.Contains(Animal)))
            {
                if (Animal == "Panda")
                {IBarManager barmanager = new BM1();
                ICalculate calculator = new PandaCalculate();
                IAnimalModle Panda = new AnimalModel.Panda(barmanager, calculator);
                    animallist.Add(Panda);
                }
                else if (Animal == "Lion")
                {
                    IBarManager barmanager = new BM1();
                    IAnimalModle Lion = new AnimalModel.Lion(barmanager);
                    animallist.Add(Lion);
                }
            }
           
        }

    }
}
