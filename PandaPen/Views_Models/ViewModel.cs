using System;
using System.Diagnostics;
using Interfaces;
using Interfaces.Events;
using System.Windows.Forms;

namespace PandaPen
{
    class ViewModel : IViewModel
    {
        /// <summary>
        /// Data Members contaions Doubles Array which is used for the bars
        /// creates a string forName contains a Individual ID
        /// </summary>
        private double[] Number01 = new double[4];
        private string formName;

        private Form VF = null;

        public ViewModel( Form TheForm)
        {
            VF = TheForm; // Creates the Form
        }
        /// <summary>
        /// Subscribes the module to the FirstPassHandler , PassCalcResultHandler and FullHappiness Handler
        /// </summary>
        /// <param name="Animal"></param>
        /// <param name="Calculate"></param>
        public void Subscribe(IAnimalModel Animal, ICalculate Calculate)
        {
            Animal.fPass += new FirstPassHandler(ReciveFirstInput); // if events reciced this methopod runs and the delegate is passed in
            Calculate.resPass += new PassCalcResultsHandler(ConvertResultsFromCalc); // if events fired this method run and delegat is passed in
            Calculate.happiness += new FullHappinessHandler(LastMove);// if events fired this method is run

        }

        /// <summary>
        /// Checks the frist input and passes infomation to the module bars at beging of program
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>

        public void ReciveFirstInput(IAnimalModel source, FirstPassArgs args)
        {
            string imageName = args.imagesource;

            for (int i = 0; i < args.values.Length; i++) // Transfars values into local double array
            {
            
                Number01[i] = args.values[i];
            }
           
            for (int i = 0; i < args.values.Length; i++) // Ensure that code is kept within valuse the progress bar can uses.
            {

                if (Number01[i] > 100)
                {
                    Number01[i] = 100;
                } 
                else if (Number01[i] < 0)
                {
                    Number01[i] = 0;
                }
            }

            if (imageName == "Panda") // these if statements select the specific image to display
            {
                (VF as View).animalPicBox.Image = PandaPen.Properties.Resources.pandapic;
            }
            else if (imageName == "Lion")
            {
                (VF as View).animalPicBox.Image = PandaPen.Properties.Resources.lionpic;
            }
           
            SendResults(); // calls this method to pass values into view
        }

        public void SendResults()
        {
            (VF as View).hungryBar.Value = Convert.ToInt32(Number01[0]); // Passess values into bars and converst double to interger
            (VF as View).energyBar.Value = Convert.ToInt32(Number01[1]);
            (VF as View).fitnessBar.Value = Convert.ToInt32(Number01[2]);
            (VF as View).happinessBar.Value = Convert.ToInt32(Number01[3]);
            
        }
        /// <summary>
        /// is used when the calucator emits it values through events
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void ConvertResultsFromCalc(ICalculate source, PassCalcResultsArgs args)
        {
            formName = (VF as IAnimalViews).fName();
            if (args.CalculatorID == formName)
            {
                for (int i = 0; i < args.values.Length; i++)
                {

                    Number01[i] = args.values[i];  
                }
            }

            SendResults(); // calls this method to pass values into view
        
        }

        /// <summary>
        /// is used when condtion is achived
        /// </summary>
        /// <param name="calc"></param>
        /// <param name="args"></param>

        public void LastMove(ICalculate calc, FullHappinessArgs args) //Deactaves all buttons and push Calculator to 100 perminatly.
        {
            if (args.CalculatorID == formName)
            {
                Number01[3] = 100;
                SendResults();
                (VF as View).eBtn.Enabled = false;
                (VF as View).sBtn.Enabled = false;
                (VF as View).fBtn.Enabled = false;
            }
        }

    }


}
