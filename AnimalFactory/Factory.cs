using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using ButtonManager;
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
        private IEnumerable<Lazy<ICalculate, IIViewMetadataCalulators>> _AvailableCaluclate;
        [ImportMany]
        private List<ICalculate> _MEFCalculators;
        ICalculate calculator;
        IButtonManager buttonmanager;
        IAnimalModle AnimalModle;
        public List<string> typeoflist = new List<string>();
        public List<IAnimalModle> animallist = new List<IAnimalModle>();
        public List<string> Calculatortype = new List<string>();


        /// <summary>
        /// the Factory Constructor Finds the Types stored in its List
        /// </summary>

        /// <summary>
        /// Method which will list all types either input manulay or used with Mef Components
        /// </summary>
        public void FindTypes()
        {
            //typeoflist.Add("Panda");
           

            foreach (Lazy<IAnimalModle, IInformationTypeMetadata> item in _AvaibaleModles)
            {
                
                typeoflist.Add(item.Metadata.description);

            }

        }

        public void FindCalctypes()
        {

            foreach (Lazy<ICalculate, IIViewMetadataCalulators> item in _AvailableCaluclate)
            {

             Calculatortype.Add(item.Metadata.CalDescription);
                
             }

        }

        /// <summary>
        /// GenerateAnimal is used as the factory Creation method Creates ALL Modules
        /// </summary>
        /// <param name="Animal"></param>
        /// <param name="ID"></param>

        public void GeneratAnimals(string Animal, int ID , string Calculator)
        {
            
            if (typeoflist.Any(str => str.Contains(Animal)))
            {
                /*if (Animal == "Lion")
                {
                                     
                    buttonmanager = new BUTTON_MANAGER();
                    calculator = new LionCalculate();
                    calculator.InitialPassIn(ID);
                    AnimalModle = new AnimalModel.Lion();
                    AnimalModle.PassinInatial(buttonmanager, calculator, ID);
                    animallist.Add(AnimalModle);
                    typeoflist.Remove("Lion");
                }
                 */
                 
                
                    buttonmanager = new BUTTON_MANAGER();
                    foreach (Lazy<IAnimalModle, IInformationTypeMetadata> item in _AvaibaleModles )
                    {
                        if(Animal == item.Metadata.description)
                        {

                            foreach (Lazy<ICalculate, IIViewMetadataCalulators> cal in _AvailableCaluclate)
                            {
                                if (Animal == cal.Metadata.description && Calculator == cal.Metadata.CalDescription)
                                {
                                  calculator = cal.Value;
                                  calculator.InitialPassIn(ID);
                                }
                            }

                                AnimalModle = item.Value;
                                AnimalModle.PassinInatial(buttonmanager, calculator, ID);
                                animallist.Add(AnimalModle);
                                typeoflist.Remove(item.Metadata.description);  
                        }
                    }

                  
                    
                    

                }
                }

    }
}

        
    


