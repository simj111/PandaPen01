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
        int Number = 0;
        int i = 0;

        /// <summary>
        /// Data Members Which Contain The View
        /// </summary>
        /// 
        DefaultView first = new DefaultView();
        View _view = null;
        ViewModel ViewM = null;
        Factory AFac1 = null;
        List<IAnimalModle> listTest = null;
        public Controller()
        {
            first.Show();
           
            AFac1 = new Factory();
            
            AddAnimalsToBox(AFac1.typeoflist);
            Subscribe(first as IThreeBarViewEvents);
             ComposeContainer();
            
           
        }

        public void CreatView(string recviedFromCombo)
        {
            if (recviedFromCombo != null)
            {
                
                i++;
                string Name = recviedFromCombo + i.ToString();
                _view = new View(Name);
                ViewM = new ViewModel(_view);
                _view.Show();
            }
        }

        public void CreateSelector()
        {
                
        }

        public void Subscribe(IThreeBarViewEvents f)
        {
            f.selectAnimal += new AnimalTypeHandler(ReciveEvents);
        }

        public void ReciveEvents(Form f, AnimalTypeArgs args)
        {

            if (args.animalTypes != null )
            {    CreatView(args._animalTypes);
                CreateFactoryAndModels(args.animalTypes);
               
            }

        }

        public void CreateFactoryAndModels(string recviedFromCombo)
        {
         
            Number++;
            IBarManager barmanager;
            
            AFac1.GeneratAnimals(recviedFromCombo, Number);
            
            listTest = AFac1.animallist;
            foreach(IAnimalModle ani in listTest)
            {
                barmanager = ani.Getbars();
                barmanager.Subscribe(_view);
                ViewM.Subscribe(ani);  
                ani.FristPassSetUP();
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
           first.animalType.Items.AddRange(new object[] {animals});
            }
        }
        public void ComposeContainer()
        {
            
            //Make sure this is at bottom of method
            Application.Run(first);
        }



    }
}
