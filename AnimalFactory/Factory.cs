using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using AnimalModel;

namespace AnimalFactory
{
    public class Factory
    {
        public List<string> typeoflist = new List<string>();
        public List<IAnimalModle> list = new List<IAnimalModle>();


        public void FindTypes()
        {
            typeoflist.Add("Panda");
        }

        public void GeneratAnimals(string Animal)
        {
            FindTypes();
            if (typeoflist.Any(str => str.Contains(Animal)))
            {
                if (Animal == "Panda")
                {
                    IAnimalModle Panda = new AnimalModel.Panda();
                    list.Add(Panda);
               

                }
            }
           
        }

    }
}
