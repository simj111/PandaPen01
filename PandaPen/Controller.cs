using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using Interfaces;
using AnimalFactory;
using Interfaces.Events;
using PandaPen.Views_Models;
using System.Diagnostics;

namespace PandaPen
{
    public class Controller 
    {
        #region DataMembers

        /// <summary>
        /// Data Members Which Contain The list of Views
        /// Contains the Numbers
        /// Containts The Factory That Creates all of the In Built IAnimalModel posstioned in the factory.
        /// </summary>
        [Import]
        public Factory AFac1;

        private List<IViewNormalSelectionofCalcs> Calview = new List<IViewNormalSelectionofCalcs>();
        private List<Form> ViewList = new List<Form>();
        private List<IViewModel> ViewModelList = new List<IViewModel>();
        public List<IAnimalModel> listOfAnimals = null;

        private string[] Combo = new string[2];
        private string[] calculatortrype = new string[2];
       

        public int NumberOfViews = 0;
        public int IDIncrement = 0;
        public int WinCalculation = 0;
        public int CurrentCalcViewID;

        private Form first;
        private Form _view = null;
        private IViewModel ViewM = null;
        private IButtonManager buttonmanager = null;
        

        #endregion DataMembers


        #region Constructors

        /// <summary>
        /// This Section Contains one Constructor. This Constructor roles it to boot up our Frist View the defualt View
        /// Add The types of Animal to the Box on the Defuult View
        /// Activate the Subsribe Method and Subscribe to the first View 
        /// Creates the Factory.
        /// Launch Method Compose Container which Binds the Mef Components 
        /// </summary>


        public Controller( Form Frist)
        {
            //todo add comments for each line here

            first = Frist;
            ComposeContainer();
            Subscribe(Frist);
            AddAnimalsToBox(AFac1.typeoflist);
            


        }
        #endregion


        #region Methods

        /// <summary>
        /// This Section of code Contains the Methods used in this section.
        /// it Contains Subscribe Which Subscribe the controller to AnimaltypeEventGenerated in the list
        /// ReciveEvents is Activated when the AnimaltypeEvents is used its purpose is to tell Pass Information to CreatView Method so a specific view can be created for that type of model and pass information into create factory so it can create the correct model.
        /// Creat View Method is used to creat specific view for differnt models based on the string that is passed in.
        /// </summary>
        /// <param name="recviedFromCombo"></param>

        /// <summary>
        /// Subscribes the Controller to the Animaltypes the form is passed in as F
        /// </summary>

        public void Subscribe(Form f)
        {
            if ((f as DefaultView) != null)
            {
                (f as DefaultView).selectAnimal += new AnimalTypeHandler(ReciveEvents);
            }


            if ((f as CalulationForms) != null)
            {
                (f as CalulationForms).selectCalc += new CalcTypeHandler(ReciveEvents2);
            }
        }

        private void CalculateSubscribe(ICalculate Cal)
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

            CurrentCalcViewID = args.ID;
            calculatortrype[args.ID] = args.calcTypes;

            f.Hide();
            CreateView();
        }

        public void ReciveEvents(Form f, AnimalTypeArgs args)
        {

            if (args.animalTypes != null)
            {


                CreatViewCalution(args._animalTypes);




            }
        }

        private void CreateView()
        {
            first.Show();
            string subchallange2Bars = "2Bars";

            if (Combo != null)
            {

                string Name = Combo[CurrentCalcViewID] + IDIncrement.ToString();

                if (Combo[CurrentCalcViewID].Contains(subchallange2Bars))
                {
                    _view = new View2Bars(Name);
                    ViewList.Add(_view);
                    ViewM = new ViewModelFor2Bars(_view);
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
               
                try
                {
                   
                 CreateFactoryAndModels(Combo[CurrentCalcViewID]);
                IDIncrement++;
                   
                }

                catch ( IndexOutOfRangeException e)
                {
                    // Perform some action here, and then throw a new exception.

                    Trace.WriteLine("You must enter a string from the array Combo for this method to work and create the factories");

            }
        }}


        /// <summary>
        /// Create Views Based on A string Passed IN
        /// </summary>
        /// <param name="recviedFromCombo"></param>

        private void CreatViewCalution(string recviedFromCombo)
        {

            Combo[CurrentCalcViewID] = recviedFromCombo;
            List<string> test = AFac1.Calculatortype;
            IViewNormalSelectionofCalcs Calculation = new CalulationForms(NumberOfViews);

            foreach (string Cals in test)
            {
                if (Cals.Contains(recviedFromCombo))
                {
                    (Calculation as CalulationForms).comboBox1.Items.AddRange(new object[] { Cals });
                }
            }


            Calview.Add(Calculation);
            (Calculation as Form).Show();
            first.Hide();
            Subscribe(Calculation as Form);

            NumberOfViews++;


        }

        /// <summary>
        ///  This Metod is responsible for passing in the string from the Combo box into the factory which is used to Build the correct model for that specific string.
        ///  It is responsible for subscribing the ButtonManager with view so it can recieve the ButtonpressEvents
        ///  Links the Viewmodel to the Calculator and its Animal together
        /// </summary>
        /// <param name="recviedFromCombo"></param>
        public void CreateFactoryAndModels(string recviedFromCombo)
        {


            try
            {
                ICalculate calculator = null;

                AFac1.GeneratAnimals(Combo[CurrentCalcViewID], CurrentCalcViewID, calculatortrype[CurrentCalcViewID]);
                (first as DefaultView).animalType.Items.Clear();
                AddAnimalsToBox(AFac1.typeoflist);
                listOfAnimals = AFac1.animallist;
                calculator = listOfAnimals[CurrentCalcViewID].Getcalc();
                CalculateSubscribe(calculator);
                buttonmanager = listOfAnimals[CurrentCalcViewID].GetButtonsForSubscibe();
                buttonmanager.Subscribe(_view);
                ViewM.Subscribe(listOfAnimals[CurrentCalcViewID], calculator);
                listOfAnimals[CurrentCalcViewID].FirstPassSetUP();
                CurrentCalcViewID++;
                if (listOfAnimals.Count == 2)
                {
                    first.Hide();
                }

            }
            catch(Exception ex)
            {
                Trace.WriteLine("Exception located in the CreateFactoryAndModels " + ex.Message);
            }
           
        

            {
               
            }
            //  Number++;
        }

        /// <summary>
        /// Add the list of animals, that the factory contains, into the combo box of the view.
        /// </summary>
        /// <param name="animalList">Used to acquire the string of animal names</param>
        private void AddAnimalsToBox(List<string> animalList)
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
                container.ComposeParts(this);
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
            WinCalculation++;
            string formNames;

            foreach (IAnimalViews a in ViewList)
            {
                formNames = a.fName();
                if (args.CalculatorID == formNames)
                {
                    for (int j = 0; j < listOfAnimals.Count; j ++)
                    {
                    string nameOfAni = listOfAnimals[j].ReturnName();

                         if (nameOfAni == args.CalculatorID)
                      {
                        buttonmanager = listOfAnimals[j].GetButtonsForSubscibe();
                      }
                    
                      }
                    buttonmanager.Unsubscribe(a);
                }
            } 
                if (NumberOfViews == WinCalculation)
                {
                    MessageBox.Show("You have won");
                    Application.Exit();
                       
                    }

                }
               
               
             
           
            }
        }
    


        #endregion


    
    

