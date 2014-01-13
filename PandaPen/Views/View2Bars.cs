using System;
using System.Drawing;
using Interfaces;
using System.Windows.Forms;
using Interfaces.Events;

namespace PandaPen
{
    /// <summary>
    /// This is The View used With Animal Contain two Bars The current Inhabitant of this area is the Gold fish Animal
    /// </summary>

    public partial class View2Bars : Form, IAnimalViews
    {
        #region DataMembers
       /// <summary>
        /// Enters Buttons when Clicked so they can be pressed there sent to ButttonPress Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private string name;

        public event ButtonPressEventHandler btnPress;
    
        #endregion DataMembers;


        
        #region Constructor


        /// <summary>
        /// The View2Bars 
        /// </summary>
        /// <param name="_name"></param>
        public View2Bars(string _name)
        {
            name = _name;
            InitializeComponent();
        }
        
        #endregion 
        
        #region Methods
        private void fBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Button1", name,1);
            btnPress(this, information);
        }

        private void cleanBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Button2", name,2);
            btnPress(this, information);
        }

        public string fName()
        {
            return name;
        }
        #endregion

    }
}
