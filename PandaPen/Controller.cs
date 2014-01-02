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
        public List<View> typeoflist = new List<View>();
        public List<ViewModel> animallist = new List<ViewModel>();
        string Animal = "Panda";

        /// <summary>
        /// Data Members Which Contain The View
        /// </summary>
        View _view = null;
        ViewModel ViewM = null;
        Factory AFac1 = null;
        public Controller()
        {
           

            //Make sure this is at bottom of constructor
            CreatView();
            ComposeContainer();
        }
      
        public void CreatView()
        {
            View _view = new View();
            ViewM = new ViewModel(_view);
        }

        public void CreateSelector()
        {
                
        }



        public void ReciveEvents()
        {

        }

        public void CreatFactoryAndModles(string recviedFromCombo)
        {   
            
            IBarManager barmanager;
            Factory AFac1 = new Factory();
            AFac1.GeneratAnimals(recviedFromCombo);
            List<IAnimalModle> listTest;
            listTest = AFac1.animallist;
            foreach(IAnimalModle ani in listTest)
            {
                barmanager = ani.bars();

                barmanager.Subscribe(_view);
            }
        }

        public void ComposeContainer()
        {
            //Make sure this is at bottom of method
            Application.Run(_view);
        }



    }
}
