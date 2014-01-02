using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces;
using AnimalFactory;
using Interfaces.Events;



namespace PandaPen
{
    class Controller : IController
    {
        public List<View> typeoflist = new List<View>();
        public List<ViewModel> animallist = new List<ViewModel>();
       

        /// <summary>
        /// Data Members Which Contain The View
        /// </summary>
        View _view = null;
        ViewModel ViewM = null;
        Factory AFac1 = null;
        List<IAnimalModle> listTest = null;
        public Controller()
        {
            CreatView();
            AFac1 = new Factory();
            
            AddAnimalsToBox(AFac1.typeoflist);
            
            Subscribe(_view as IViewEvents);
            ComposeContainer();
        }
      
        public void CreatView()
        {
            _view = new View();
            ViewM = new ViewModel(_view);
        }

        public void CreateSelector()
        {
                
        }

public void Subscribe(IViewEvents f)
        {
            f.selectAnimal += new AnimalTypeHandler(ReciveEvents);
        }

public void ReciveEvents(Form f, AnimalTypeArgs args)
        {

            if (args.animalTypes == "Panda")
            {
                CreateFactoryAndModels(args.animalTypes);
            }

        }

        public void CreateFactoryAndModels(string recviedFromCombo)
        {   
            
            IBarManager barmanager;
            
            AFac1.GeneratAnimals(recviedFromCombo);
            
            listTest = AFac1.animallist;
            foreach(IAnimalModle ani in listTest)
            {
                barmanager = ani.bars();

                barmanager.Subscribe(_view);
            }
           
        }

        /// <summary>
        /// Add the list of animals, that the factory contains, into the combo box of the view.
        /// </summary>
        /// <param name="animalList">Used to acquire the string of animal names</param>
        public void AddAnimalsToBox(List<string> animalList)
        {
            foreach (string animals in animalList)
            {
            _view.animalType.Items.AddRange(new object[] {animals});
            }
        }
        public void ComposeContainer()
        {
            
            //Make sure this is at bottom of method
            Application.Run(_view);
        }



    }
}
