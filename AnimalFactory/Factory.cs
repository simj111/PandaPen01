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
        /// Contains A List of types.
        /// Contains An Animal Model.
        /// Contains A double ID.
        /// </summary> 
    public class Factory
    {
        [ImportMany]
        private IEnumerable<Lazy<IAnimalModel, IAnimalTypeMetadata>> _AvailableModels;  // Imported Animal modles with Metedata used in GenerateAnimals
        [ImportMany]
        private IEnumerable<Lazy<ICalculate, IViewMetadataCalculators>> _AvailableCalculate; // Imported Available Calcualte modles with metedata used in GenerateAnimals

        public List<string> typeoflist = new List<string>();
        public List<IAnimalModel> animallist = new List<IAnimalModel>();
        public List<string> Calculatortype = new List<string>();

        /// <summary>
        /// Method which will list all types either input manually or used with MEF Components
        /// </summary>
        /// 

        public void FindTypes()
        {
            foreach (Lazy<IAnimalModel, IAnimalTypeMetadata> item in _AvailableModels) // Finds all types of Aninmals in the Modle from imported MeteData and adds data to list.
            {
                typeoflist.Add(item.Metadata.AnimalType); 
            }
            
        }

        public void FindCalctypes()
        {
            foreach (Lazy<ICalculate, IViewMetadataCalculators> item in _AvailableCalculate) // Finds all types of Avaliable Calculators and puts there metea data into the area.
            {
             Calculatortype.Add(item.Metadata.CalDescription); 
            }
        }

        /// <summary>
        /// GenerateAnimals is used as the factory's creation method. It creates all of the animal models.
        /// </summary>
        /// <param name="Animal"></param>
        /// <param name="ID"></param>
        public void GenerateAnimals(string Animal, int ID , string Calculator) // Generates all Animals In our Modle
        {
            
            ICalculate calculator = null; // Spawns a unassigned Calculator 
            IButtonManager buttonmanager = null; // Spawns a unassigned Calculator 
            IAnimalModel AnimalModel = null; // Spawns a unassigned Calculator 

            if (typeoflist.Any(str => str.Contains(Animal))) // Spawns Calculator and if animal value has been passed in
            {
                    buttonmanager = new BUTTON_MANAGER();// Creates a new ButtonManger for each Animal
                    foreach (Lazy<IAnimalModel, IAnimalTypeMetadata> item in _AvailableModels ) // steps through list Available modles 
                    {

                        if (Animal == item.Metadata.AnimalType) // Checks if the Meta data matches the 
                        {

                            foreach (Lazy<ICalculate, IViewMetadataCalculators> cal in _AvailableCalculate) // If true Activates this loop
                            {

                                if (Calculator == cal.Metadata.CalDescription)// fires statemnt when it finds the correct Caltort and puts it calculator italso pass in an Inital Calulator value.
                                {
                                  calculator = cal.Value;
                                  calculator.InitialPassIn(ID);
                                }

                            }

                          AnimalModel = item.Value; // gives the local variable the new Animals value
                          AnimalModel.PassinInatial(buttonmanager, calculator, ID); // gives the New Animal its start up Paramaters
                          animallist.Add(AnimalModel); // Adds this Animal to the list
                          typeoflist.Remove(item.Metadata.AnimalType);   // Removes metat data so it can never be picked again

                        }
                   }
             }
        }
    }
}

        
    


