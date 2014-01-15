using System;
using System.Drawing;
using Interfaces;
using System.Windows.Forms;
using Interfaces.Events;

namespace PandaPen
{
    public partial class CalculationForms : Form , IViewNormalSelectionofCalcs
    {
        /// <summary>
        /// The Data Members contain a ID number and an Event to link up to the CalcTypeHandler Delegate 
        /// </summary>
        private int CatchthenumberID;
        public event CalcTypeHandler selectCalc;
        /// <summary>
        /// This form is for creating a Cal view which is used to selecte the calctor type for the Animal
        /// </summary>
        /// <param name="ID"></param>
        public CalculationForms(int ID)
        {
            CatchthenumberID = ID; // Pass in unquie Identifire
            InitializeComponent();
        }

        /// <summary>
        /// This method is fired when the player selcts an animal its fired so the resut of the program knows what calculator to create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // This method is used when the User slect a Animal they wish to play
        {
            CalcTypeArgs information = new CalcTypeArgs(comboBox1.Text,CatchthenumberID); // Pass out the number to the controller
            selectCalc(this, information); //pass out the Form and args to Delagate
        }
    }
}
