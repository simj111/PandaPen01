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
    /// This the Defualt View and is the First View you see
    /// </summary>
    public partial class DefaultView : Form 
         
    {
        /// <summary>
        /// These Data Members Contain two Events the Annimal type Events is used to select the view to display.
        /// </summary>

         public event AnimalTypeHandler selectAnimal;
        
        
        public DefaultView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// used to Generate the Game Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     
            private void animalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimalTypeArgs animalTypes = new AnimalTypeArgs(animalType.Text);

            selectAnimal (this, animalTypes);
        }

           
    }
    }
