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
        /// <summary>
        /// Contains A List of types
        /// Contains A Animal Modle
        /// Contains A double ID
        /// </summary>

        public List<string> typeoflist = new List<string>();
        public List<IAnimalModle> animallist = new List<IAnimalModle>();
        double ID = 0;

        /// <summary>
        /// the Factory Constructor Finds the Types stored in its List
        /// </summary>

        public Factory()
        {
           

            FindTypes();
        }

        /// <summary>
        /// Method which will list all types either input manulay or used with Mef Components
        /// </summary>
        public void FindTypes()
        {
            typeoflist.Add("Panda");
            typeoflist.Add("Lion");
        }
        /// <summary>
        /// GenerateAnimal is used as the factory Creation method Creates ALL Modules
        /// </summary>
        /// <param name="Animal"></param>
        /// <param name="ID"></param>

        public void GeneratAnimals(string Animal, int ID)
        {
            
            if (typeoflist.Any(str => str.Contains(Animal)))
            {   

                if (Animal == "Panda")
                {
                    IAnimalModle Panda = null;
                    IBarManager barmanager = new PandaBM();
                    ICalculate calculator = new PandaCalculate();
                    Panda = new AnimalModel.Panda(barmanager, calculator, ID);
               
                    animallist.Add(Panda);
                }
                else if (Animal == "Lion")
                {
                    IBarManager barmanger;
                    IAnimalModle Lion;
                    barmanger = new LionBM2();
                    ICalculate calculator = new PandaCalculate();
                    Lion = new AnimalModel.Lion(barmanger, calculator, ID);
                    animallist.Add(Lion);
                }
            }
           
        }

    }
}
