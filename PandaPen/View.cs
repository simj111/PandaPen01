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
    public partial class View : Form, IViewEvents
    {

        public event ButtonPressEventHandler btnPress;
        public event AnimalTypeHandler selectAnimal;

        public View()
        {
            InitializeComponent(); 
        }

        private void fBtn_Click(object sender, EventArgs e)
        {
          
            ButtonPressEventArgs information = new ButtonPressEventArgs("Eat");
            if (information != null)
            {
            btnPress(this, information);
            }
            else 
            {

            }
        }

        private void sBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Sleep");

            btnPress(this, information);
        }

        private void eBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Exercise");

            btnPress(this, information);
        }

        private void animalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimalTypeArgs animalTypes = new AnimalTypeArgs(animalType.Text);

            selectAnimal(this, animalTypes);
        }


    }
}
