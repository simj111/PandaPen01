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
        double ID = 0;
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
            {    ++ID;

                if (Animal == "Panda")
                {
                    IAnimalModle Panda = null;
                    IBarManager barmanager = new BM1();
                    ICalculate calculator = new PandaCalculate();
                    Panda = new AnimalModel.Panda(barmanager, calculator, ID);
               
                    animallist.Add(Panda);
                }
                else if (Animal == "Lion")
                {
                    IBarManager barmanger;
                    IAnimalModle Lion; 
                    barmanger = new BM1();
                    ICalculate calculator = new PandaCalculate();
                    Lion = new AnimalModel.Lion(barmanger, calculator, ID);
                    animallist.Add(Lion); 
                   
                    
                    
                   
                    
                   
                }
            }
           
        }

    }
}
