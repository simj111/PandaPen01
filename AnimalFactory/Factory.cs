using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using BarManager;
using AnimalModel;
using MEFClassLibary;
using System.Diagnostics;
using System.ComponentModel.Composition;
using CalculatorLibrary;

namespace AnimalFactory
{
 [Export(typeof(Factory))]


   public class Factory
    {

        /// <summary>
        /// Contains A List of types
        /// Contains A Animal Modle
        /// Contains A double ID
        /// </summary> 
        /// 




        [ImportMany] 
        private IEnumerable<Lazy<IAnimalModle, IInformationTypeMetadata>> _AvaibaleModles;
        [ImportMany] 
        private List<IAnimalModle> _avaibaleModles;

                [ImportMany] 

        private List<ICalculate> _MEFCALCULATORS;
      

        public List<string> typeoflist = new List<string>();
        public List<IAnimalModle> animallist = new List<IAnimalModle>();


        /// <summary>
        /// the Factory Constructor Finds the Types stored in its List
        /// </summary>

        public Factory()
        {


            //FindTypes();
        }

        /// <summary>
        /// Method which will list all types either input manulay or used with Mef Components
        /// </summary>
        public void FindTypes()
        {
            typeoflist.Add("Panda");
            typeoflist.Add("Lion");

            foreach (Lazy<IAnimalModle, IInformationTypeMetadata> item in _AvaibaleModles)
            {
                typeoflist.Add(item.Metadata.description);

            }

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
                               calculator.InitialPassIn(ID);
                    Panda = new AnimalModel.Panda(barmanager, calculator, ID);

                    animallist.Add(Panda);
                    typeoflist.Remove("Panda");
                }
                else if (Animal == "Lion")
                {
                    
                    IBarManager barmanger;
                    IAnimalModle Lion;
                    barmanger = new LionBM2();
                    ICalculate calculator = new LionCalculate();
                               calculator.InitialPassIn(ID);
                    Lion = new AnimalModel.Lion();
                    Lion.PassinInatial(barmanger, calculator, ID);
                    animallist.Add(Lion);
                    typeoflist.Remove("Lion");
                }
                else if (Animal == "GoldFish2Bars" && typeoflist.Contains(Animal))
                {

                    IBarManager barmanger = new GoldfishBM1();
                    ICalculate cally;
                    foreach (ICalculate calculators in _MEFCALCULATORS)
                    {
                        cally = calculators;



                        foreach (IAnimalModle animalmef in _avaibaleModles)
                        {
                            

                            (animalmef as GoldFish).PassinInatial(barmanger, cally, ID);
                            animallist.Add(animalmef);
                            typeoflist.Remove("GoldFish2Bars");

                        }
                    }

                }
                }

            }

        }
    }


