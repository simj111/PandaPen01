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
    public partial class View2Bars : Form, ITWOEVENTS, IThreeBarViewEvents
    {
        public string name;
        public View2Bars(string _name)
        {
            name = _name;
            InitializeComponent();
        }

        private void fBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("EatFishFood", name);
          

            btnPress(this, information);

        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("CleaningAir", name);
            

            btnPress(this, information);
        }

        public event ButtonPressEventHandler btnPress;

        private void hungryBar_Click(object sender, EventArgs e)
        {

        }
    }
}
