using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using Interfaces;
using AnimalFactory;
using Interfaces.Events;
using PandaPen.Views_Models;
using Selector;
using System.Diagnostics;




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

   //     [Import]
   //     private ISelector _modelSelector = null;

        [Import]
        private Factory AFac1;
        //[Import] private ICalutor
        public List<IViewNoramlSelectionofCalcs> Calview = new List<IViewNoramlSelectionofCalcs>();
        public List<Form> ViewList = new List<Form>();
        public List<IViewModel> ViewModelList = new List<IViewModel>();
        private string Combo;
        string calculatortrype;
        int Number = 0;
        int i = 0;
        int  Wincalucation = 0;
        Form first = new DefaultView();
        Form _view = null;
        IViewModel ViewM = null;

        List<IAnimalModle> listTest = null;

        IButtonManager buttonmanager;
        ICalculate calculator;




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
            ComposeContainer();
            Subscribe(first);
            AddAnimalsToBox(AFac1.typeoflist);
            Application.Run(first);


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
            if ( (f as DefaultView) != null )
            {
                (f as DefaultView).selectAnimal += new AnimalTypeHandler(ReciveEvents);
            }
                
               
            if ((f as CalulationForms) != null)
            {
                (f as CalulationForms ).selectCalc += new CalcTypeHandler(ReciveEvents2);
            }
        }

        public void CalculateSubscribe(ICalculate Cal)
        {
           Cal.happiness += new FullHappinessHandler(CheckWinCondition);
        }



        /// <summary>
        /// is used to see if Animal types is not null to pass in the string Argument Animal types into the view.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>

        public void ReciveEvents2(Form f, CalcTypeArgs args)
        {
            calculatortrype = args._calcTypes;
            f.Close();
            CreateView();
        }

        public void ReciveEvents(Form f, AnimalTypeArgs args)
        {

            if (args.animalTypes != null)
            {


                CreatViewCalution(args._animalTypes);
               
            


            }
        }

        public void CreateView()
        {
             string subchallange2Bars = "2Bars";

             if (Combo != null)
            {

                string Name = Combo + i.ToString();

                if (Combo.Contains(subchallange2Bars))
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

                CreateFactoryAndModels(Combo);
                    i++;
                
                
        }}


        /// <summary>
        /// Create Views Based on A string Passed IN
        /// </summary>
        /// <param name="recviedFromCombo"></param>

        public void CreatViewCalution(string recviedFromCombo)
        {
            Combo = recviedFromCombo;
            List<string> test = AFac1.Calculatortype;
            IViewNoramlSelectionofCalcs Calculation = new CalulationForms();
           
            foreach (string Cals in test)
            {
                if (Cals.Contains(recviedFromCombo))
                {
                    (Calculation as CalulationForms).comboBox1.Items.AddRange(new object[] { Cals });
                }
            }


            Calview.Add(Calculation);
            (Calculation as Form).Show();

            Subscribe(Calculation as Form);
            
            
            
           
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


            {





                AFac1.GeneratAnimals(recviedFromCombo, Number, calculatortrype);
                (first as DefaultView).animalType.Items.Clear();
                AddAnimalsToBox(AFac1.typeoflist);
                
                
                
                
                listTest = AFac1.animallist;
                calculator = listTest[Number].Getcalc();
                CalculateSubscribe(calculator);
                buttonmanager = listTest[Number].GetButtonsForSubscibe();
                buttonmanager.Subscribe(_view);
                ViewM.Subscribe(listTest[Number], calculator);
                listTest[Number].FristPassSetUP();

            }

            Number++;
        }

        /// <summary>
        /// Add the list of animals, that the factory contains, into the combo box of the view.
        /// </summary>
        /// <param name="animalList">Used to acquire the string of animal names</param>
        public void AddAnimalsToBox(List<string> animalList)
        {
            foreach (string animals in animalList)
            {
                (first as DefaultView).animalType.Items.AddRange(new object[] { animals });
            }
        }
        /// <summary>
        /// Contains the Compose Container method which add all Mef Components in it.
        /// </summary>

        public void ComposeContainer()
        {

            DirectoryCatalog catalog = new DirectoryCatalog("..\\MEFBOX\\");

            CompositionContainer container = new CompositionContainer(catalog);

            try
            {
                //  _modelSelector.getAvailableModels();

                container.ComposeParts(this);
                //   _modelSelector.getAvailableModels();
                AFac1.FindTypes();
                AFac1.FindCalctypes();



            }
            catch (CompositionException e)
            {
                Trace.WriteLine("Composition failed");
                Trace.WriteLine(e.Message);

            }



        }

        public void CheckWinCondition(ICalculate f, FullHappinessArgs args)
        {
            int i = Number;
            if (args.happiness != null)
            {
            
             _view = ViewList[Wincalucation]; 
             buttonmanager.Unsubscribe(_view);
            Wincalucation++;
            }
            if (i == Wincalucation)
            {
                MessageBox.Show("You have won");           
            }

               
          
             
                
            }
        }


        #endregion


    }
    

