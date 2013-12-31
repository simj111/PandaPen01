using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces;
using AnimalFactory;



namespace PandaPen
{
    class Controller
    {
        View _view = new View();
       
        public Controller()
        {


            //Make sure this is at bottom of constructor
            ComposeContainer();
        }
        
        public void ComposeContainer()
        {
            IBarManager barmanager;
            Factory AFac1 = new Factory();
            AFac1.GeneratAnimals("Panda");
      
            List<IAnimalModle> listTest;
            listTest = AFac1.animallist;
            foreach(IAnimalModle ani in listTest)
            {
                barmanager = ani.bars();

                barmanager.Subscribe(_view);
            }

            
            

            //Make sure this is at bottom of method
            Application.Run(_view);
        }



    }
}
