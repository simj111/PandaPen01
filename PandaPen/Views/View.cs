using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces.Events;
using Interfaces;

namespace PandaPen
{
    /// <summary>
    /// Partial Class of the Three Bar Animal Views
    /// </summary>
    public partial class View : Form, IThreeBarViewEvents
    {
        /// <summary>
        /// The Data Members Contains this View unguie identfire whic is name
        /// </summary>
        public string name;
        public event ButtonPressEventHandler btnPress;
        public event AnimalTypeHandler selectAnimal;


        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="_name"></param>
        public View( string _name)
        {
            name = _name;
            InitializeComponent(); 
        }

        private void fBtn_Click(object sender, EventArgs e)
        {
            
            {
                ButtonPressEventArgs information = new ButtonPressEventArgs("Eat", name);

                btnPress(this, information);
            }

        }

        private void sBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Sleep", name);

            btnPress(this, information);
        }

        private void eBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Exercise", name);

            btnPress(this, information);
        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

      

       


    }
}
