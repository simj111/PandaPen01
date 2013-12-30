using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using interfaces.Interface;
using interfaces.Events;
using Animal_Model;

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
            if (typeoflist.Any(str => str.Contains(Animal)))
            {
                if (Animal == "Panda")
                {
                    IAnimalModle Panda = new Animal_Model.Panda();
                    list.Add(Panda);
               

                }
            }
           
        }

    }
}
