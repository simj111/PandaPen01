using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Interfaces.Events;
using ButtonManager;
using System.Diagnostics;
using System.ComponentModel.Composition;

namespace AnimalFactory
{
    [Export(typeof(Factory))]

        /// <summary>
        /// Contains A List of types
        /// Contains A Animal Model
        /// Contains A double ID
        /// </summary> 
    public class Factory
    {
        [ImportMany]
        private IEnumerable<Lazy<IAnimalModel, IAnimalTypeMetadata>> _AvailableModels;
        [ImportMany]
        private IEnumerable<Lazy<ICalculate, IViewMetadataCalculators>> _AvailableCalculate;

        public List<string> typeoflist = new List<string>();
        public List<IAnimalModel> animallist = new List<IAnimalModel>();
        public List<string> Calculatortype = new List<string>();

        /// <summary>
        /// Method which will list all types either input manually or used with Mef Components
        /// </summary>
        /// 

        public void FindTypes()
        {
            foreach (Lazy<IAnimalModel, IAnimalTypeMetadata> item in _AvailableModels)
            {
                typeoflist.Add(item.Metadata.AnimalType);
            }
            
        }

        public void FindCalctypes()
        {
            foreach (Lazy<ICalculate, IViewMetadataCalculators> item in _AvailableCalculate)
            {
             Calculatortype.Add(item.Metadata.CalDescription); 
            }
        }

        /// <summary>
        /// GenerateAnimal is used as the factory Creation method Creates ALL models
        /// </summary>
        /// <param name="Animal"></param>
        /// <param name="ID"></param>
        public void GeneratAnimals(string Animal, int ID , string Calculator)
        {
            
            ICalculate calculator = null;
            IButtonManager buttonmanager = null;
            IAnimalModel AnimalModel = null;

            if (typeoflist.Any(str => str.Contains(Animal)))
            {
                    buttonmanager = new BUTTON_MANAGER();
                    foreach (Lazy<IAnimalModel, IAnimalTypeMetadata> item in _AvailableModels )
                    {

                        if (Animal == item.Metadata.AnimalType)
                        {

                            foreach (Lazy<ICalculate, IViewMetadataCalculators> cal in _AvailableCalculate)
                            {

                                if (Animal == cal.Metadata.AnimalType && Calculator == cal.Metadata.CalDescription)
                                {
                                  calculator = cal.Value;
                                  calculator.InitialPassIn(ID);
                                }

                            }

                          AnimalModel = item.Value;
                          AnimalModel.PassinInatial(buttonmanager, calculator, ID);
                          animallist.Add(AnimalModel);
                          typeoflist.Remove(item.Metadata.AnimalType);  

                        }
                   }
             }
        }
    }
}

        
    


