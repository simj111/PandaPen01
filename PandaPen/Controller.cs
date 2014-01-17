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
        /// Contains public number which are used to count the views
        /// Containts The Factory That Creates all of the In Built IAnimalModel posstioned in the factory.
        /// Contains lists of exsting Formes modeles and Calculation infomation sotred with the Control.
        /// Imported the factory into the Main Controler
        /// </summary>
        [Import]
        public Factory AFac1;

        private List<IViewNormalSelectionofCalcs> Calview = new List<IViewNormalSelectionofCalcs>();
        private List<Form> ViewList = new List<Form>();
        private List<IViewModel> ViewModelList = new List<IViewModel>();
        public List<IAnimalModel> listOfAnimals = null;

        private string[] Combo = new string[2]; // Contains the strings that will passed in from Defult View
        private string[] calculatortrype = new string[2]; // Contains the string that are passed for Calculator View 
       

        public int NumberOfViews = 0; // Contains the number views 
        public int IDIncrement = 0; // Contains the ID incrment which needs to passed into the views
        public int WinCalculation = 0; // is used to help caculate the win value
        public int CurrentCalcViewID;

        private Form first; // The defult view
        private Form _view = null; // the Form _view
        private IViewModel ViewM = null; // The View modle
        private IButtonManager buttonmanager = null; // used to help subscibe and unsubscribe the button managers
        

        #endregion DataMembers


        #region Constructors

        /// <summary>
        /// This Section Contains one Constructor. This Constructor roles it to boot up our Frist View the defualt View
        /// Add The types of Animal to the Box on the Defuult View
        /// Activate the Subsribe Method and Subscribe to the first View 
        /// Launch Method Compose Container which Binds the Mef Components 
        /// </summary>


        public Controller( Form Frist)
        {
            //todo add comments for each line here
            first = Frist; // Pass the defult view to data members
            ComposeContainer(); // Compose the Mef Compents
            Subscribe(Frist);
            AddAnimalsToBox(AFac1.typeoflist);
            


        }
        #endregion


        #region Methods

        /// <summary>
        /// This section of code Contains the Methods used in this section.
        /// it contains subscribe which subscribe the controller to AnimaltypeEventGenerated in the list
        /// ReciveEvents is activated when the AnimaltypeEvents is used its purpose is to tell Pass Information to CreatView method so a specific view can be created for that type of model and pass information into create factory so it can create the correct model.
        /// Creat View Method is used to creat specific view for differnt models based on the string that is passed in.
        /// </summary>
        /// <param name="recviedFromCombo"></param>

        /// <summary>
        /// Subscribes the Controller to the Animaltypes the form is passed in as F
        /// this subscriber is the the controler to both the CalculationForms and 
        /// DefaultView
        /// </summary>

        public void Subscribe(Form f)
        {
            if ((f as DefaultView) != null)
            {
                (f as DefaultView).selectAnimal += new AnimalTypeHandler(ReceiveEvents); 
            }


            if ((f as CalculationForms) != null)
            {
                (f as CalculationForms).selectCalc += new CalcTypeHandler(ReceiveEvents2);
            }
        }

        /// <summary>
        /// Subscribes the Calculation forms to the Controle so it cal lissten out for the FullHappines Handler event
        /// </summary>
        /// <param name="Cal"></param>

        private void CalculateSubscribe(ICalculate Cal) // Subsbire the calcations to a wind condition
        {
            Cal.happiness += new FullHappinessHandler(CheckWinCondition);

        }


        /// <summary>
        /// is used to create Recive Events which spawns the Calculator form
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>

        public void ReceiveEvents(Form f, AnimalTypeArgs args)
        {

            if (args.animalTypes != null)
            {


                CreatViewCalution(args._animalTypes);




            }
        }

        /// <summary>
        /// is used to see if Animal types is not null to pass in the string Argument Animal types into the view.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>

        public void ReceiveEvents2(Form f, CalcTypeArgs args)
        {

            CurrentCalcViewID = args.ID; // gets the current view id that passed it in
            calculatortrype[args.ID] = args.calcTypes; // addes the selected calculator to an array where it can be storted for uses

            f.Hide(); // hides the view so it can be reaccessed 
            CreateView(); // Creates the main animal view
        }
       
        /// <summary>
        /// Create Views Calucation on A string Passed In from defualt view
        /// </summary>
        /// <param name="recviedFromCombo"></param>

        private void CreatViewCalution(string recviedFromCombo)
        {

            Combo[CurrentCalcViewID] = recviedFromCombo;
            List<string> test = AFac1.Calculatortype;
            IViewNormalSelectionofCalcs Calculation = new CalculationForms(NumberOfViews);

            foreach (string Cals in test)
            {
                if (Cals.Contains(recviedFromCombo))
                {
                    (Calculation as CalculationForms).comboBox1.Items.AddRange(new object[] { Cals });
                }
            }


            Calview.Add(Calculation);
            (Calculation as Form).Show();
            first.Hide();
            Subscribe(Calculation as Form);

            NumberOfViews++;


        }



        /// <summary>
        /// is used to Create the View system and spwan the animal it also checks for 2Bars in code so it can Generate the correct views.
        /// 
        /// </summary>

        private void CreateView()
        {
            first.Show(); // respawns the defualt view so people can sellect the second animal if they wish 
            string subchallange2Bars = "2Bars"; // ask for 2bars logic

            if (Combo != null) //check if not equal null
            {

                string Name = Combo[CurrentCalcViewID] + IDIncrement.ToString(); // Passed indvidual identifier

                if (Combo[CurrentCalcViewID].Contains(subchallange2Bars)) // checks if 2 bars view hass been selected.
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
                   
                 CreateFactoryAndModels(Combo[CurrentCalcViewID]); // Sends the Animal string to Create Factory and Modles.
                IDIncrement++;
                   
                }

                catch ( IndexOutOfRangeException e)
                {
                    // Perform some action here, and then throw a new exception.

                    Trace.WriteLine("You must enter a string from the array Combo for this method to work and create the factories");

            }
        }}


      

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
                ICalculate calculator = null; // used as local refernce for calotor to subscibe events

                AFac1.GenerateAnimals(Combo[CurrentCalcViewID], CurrentCalcViewID, calculatortrype[CurrentCalcViewID]); // pass in infomation when view is selected
                (first as DefaultView).animalType.Items.Clear(); //clears the list so that line below can re add it with the selction just inputed removed. which is passed to views
                AddAnimalsToBox(AFac1.typeoflist);
                listOfAnimals = AFac1.animallist;
                calculator = listOfAnimals[CurrentCalcViewID].Getcalc(); // gets the calctor using the get calc methods
                CalculateSubscribe(calculator); // Subscibes it to the Calculator
                buttonmanager = listOfAnimals[CurrentCalcViewID].GetButtonsForSubscibe(); //Gets the ButtonsManger and Subscribes
                buttonmanager.Subscribe(_view);
                ViewM.Subscribe(listOfAnimals[CurrentCalcViewID], calculator); // Subscribes the Animal and caltor for events frist pass and caclator events
                listOfAnimals[CurrentCalcViewID].FirstPassSetUP(); // Launches the Method which will launch a method that will work effectivly
                CurrentCalcViewID++;// Updates the current views
                if (listOfAnimals.Count == 2)
                {
                    first.Hide(); // Kills the defualt view for last time
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
        /// Contains the Compose Container method which add all Mef Components in this method.
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

        /// <summary>
        /// make sure the Windcontion is listend 
        /// for and the sytem acts Accordingly.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="args"></param>

        public void CheckWinCondition(ICalculate f, FullHappinessArgs args)
        {
            WinCalculation++; 
            string formNames;

            foreach (IAnimalViews a in ViewList)
            {
                formNames = a.fName(); // check unquie identifer
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
                    buttonmanager = null;
                }
            } 
                if (NumberOfViews == WinCalculation)
                {
                    MessageBox.Show("You have won"); // closes and exits the porgramme
                    Application.Exit();
                       
                    }

                }
               
               
             
           
            }
        }
    


        #endregion


    
    

