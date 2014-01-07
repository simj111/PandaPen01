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
        #region DataMembers

        /// <summary>
        /// Data Members Which Contain The list of View
        /// Contains the Numbers
        /// Containts The Factory That Creates all of the In Built IAnimalModle posstioned in the factory.
        /// </summary>
       
       
        public List<Form> ViewList = new List<Form>();
        public List<IViewModel> ViewModelList = new List<IViewModel>();

        int Number = 0;
        int i = 0;

        Form first = new DefaultView();
        Form _view = null;
        Form OtherViews;
        IViewModel ViewM = null;
        Factory AFac1 = null;
        List<IAnimalModle> listTest = null;
      
        #endregion DataMembers


        #region Constructors

       /// <summary>
       /// This Section Contains one Constructor. This Constructor roles it to boot up our Frist View the defualt View
       /// Add The types of Animal to the Box on the Defuult View
       /// Activate the Subsribe Method and Subscribe to the first View 
       /// Creates the Factory.
       /// Launch Method Compose Container which Binds the Mef Components 
       /// </summary>
        
        
        public Controller()
        {
            first.Show();
            AFac1 = new Factory();
            AddAnimalsToBox(AFac1.typeoflist);
            Subscribe(first);
            ComposeContainer();         
        }
        #endregion

      
        #region Methods

        /// <summary>
        /// This Section of code Contains the Methods used in this section.
        /// it Contains Subscribe Which Subscribe the controler to AnimaltypeEventGenerated in the list
        /// ReciveEvents is Activated when the AnimaltypeEvents is used its purpouse is to tell Pass Infomation to CreatView Method so a specific view can be created for that type of modle and pas infomation into create factory so it can creat the correct module.
        /// Creat View Method is used to creat specific view for differnt modules based on the string that is passed in.
        /// Creat Selctor is used to plug in Mef Components.
        /// </summary>
        /// <param name="recviedFromCombo"></param>

        /// <summary>
        /// Subscribes the Controler to the Animaltypes the form is passed in as F
        /// </summary>

         public void Subscribe(Form f)
        {
            (f as DefaultView).selectAnimal += new AnimalTypeHandler(ReciveEvents);
        }

        /// <summary>
        /// is used to see if Animal types is not null to pass in the string Argument Animal types into the view.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>
        
        public void ReciveEvents(Form f, AnimalTypeArgs args)
        {

            if (args.animalTypes != null )
            {   
                CreatView(args._animalTypes);
                CreateFactoryAndModels(args.animalTypes);
               
            }
        }

        /// <summary>
        /// Create Views Based on A string Passed IN
        /// </summary>
        /// <param name="recviedFromCombo"></param>

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

        /// <summary>
        /// Creates the Selector for all Mef Compontes so All Imported Componets Can be used
        /// </summary>
        public void CreateSelector()
        {
                
        }
        /// <summary>
        ///  This Metod is resposnible for passing in the string from the Combox into the factory which is used to Build the correct modle for that specfic string.
        ///  It is reposnibe for subscribing the Barmanger with view so it can recive the ButtonpressEvents
        ///  Links the ViewModule to the Calator and its Animal together
        /// </summary>
        /// <param name="recviedFromCombo"></param>
        public void CreateFactoryAndModels(string recviedFromCombo)
        {

          IBarManager barmanager;
          ICalculate calculator;
                                {
                                AFac1.GeneratAnimals(recviedFromCombo, Number);
                                listTest = AFac1.animallist;
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
        /// <summary>
        /// Contains the Compose Container method which add all Mef Components in it.
        /// </summary>

        public void ComposeContainer()
        {            
       
         Application.Run(first);
        }
        #endregion


    }
}
