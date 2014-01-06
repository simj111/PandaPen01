using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces;
using AnimalFactory;
using Interfaces.Events;
using PandaPen.Views_Models;



namespace PandaPen
{
    class Controller : IController
    {
        public List<Form> ViewList = new List<Form>();
        public List<IViewModel> ViewModelList = new List<IViewModel>();

        int Number = 0;
        int i = 0;

        /// <summary>
        /// Data Members Which Contain The View
        /// </summary>
        /// 
        Form first = new DefaultView();
        Form _view = null;
        Form OtherViews;
        IViewModel ViewM = null;
        Factory AFac1 = null;
        List<IAnimalModle> listTest = null;
        public Controller()
        {
            first.Show();
           
            AFac1 = new Factory();
            
            AddAnimalsToBox(AFac1.typeoflist);
            Subscribe(first);
            ComposeContainer();
            
           
        }

        public void CreatView(string recviedFromCombo)
        {
            string subchallange2Bars = "2Bars";
            
            if (recviedFromCombo != null)
            {
            
                string Name = recviedFromCombo + i.ToString();

                if (recviedFromCombo.Contains(subchallange2Bars))
                {
                    _view = new View2Bars(Name);
                    ViewList.Add(_view);
                    ViewM = new ViewModleFor2Bars(_view);
                    ViewModelList.Add(ViewM);

                    _view.Show();
                }
                else
                {
                    _view = new View(Name);
                    ViewList.Add(_view);
                    ViewM = new ViewModel(_view);
                    ViewModelList.Add(ViewM);
                    _view.Show();
                   
                }
                  i++; 
            }
        }

        public void CreateSelector()
        {
                
        }

        public void Subscribe(Form f)
        {
            (f as DefaultView).selectAnimal += new AnimalTypeHandler(ReciveEvents);
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
           
           
            IBarManager barmanager;
            ICalculate calculator;
            
            AFac1.GeneratAnimals(recviedFromCombo, Number);
            
             listTest = AFac1.animallist;
             
               
            {
                calculator = listTest[Number].Getcalc();
                barmanager = listTest[Number].Getbars();
                barmanager.Subscribe(_view);
                ViewM.Subscribe(listTest[Number], calculator);
                listTest[Number].FristPassSetUP();
                Number++;
                
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
             (first as DefaultView).animalType.Items.AddRange(new object[] {animals});
            }
        }
        public void ComposeContainer()
        {
            
            //Make sure this is at bottom of method
            Application.Run(first);
        }



    }
}
