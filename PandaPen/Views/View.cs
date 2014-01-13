using System;
using System.Drawing;
using Interfaces;
using System.Windows.Forms;
using Interfaces.Events;

namespace PandaPen
{
    
    /// <summary>
    /// Partial Class of the Three Bar Animal Views is Used with the Panda and Lion Animal in the orginal Verisons of the game.
    /// </summary>
    
    public partial class View : Form, IAnimalViews
    {
        #region DataMembers
        /// <summary>
        /// The Data Members Contains this View unguie identfire which is named by the Factory of the AnimalModel this View realtes to.
        /// Also Contains ButtonPress event handaler so it can shout out events around the Program to the Delegat In barManger
        /// </summary>
     
        private string name;
        private int Number = 0;

        public event ButtonPressEventHandler btnPress;
        public event CalcTypeHandler selectCalc;
       
        #endregion 


        #region Constructor

        /// <summary>
        /// Constructor Which Continas an Name which is given on creation and links to a similr string for the module paring the two together
        /// Contains IntializeComponets Which Boot up all Visuals for the view
        /// </summary>
        /// <param name="_name"></param>
        
        public View( string _name)
        {
            name = _name;
            InitializeComponent(); 
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Contain Enternal Buton Click Events that listen for the Bottons being pressed by the mouse
        ///  Enters Buttons when Clicked so they can be pressed there sent to ButttonPress Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void fBtn_Click(object sender, EventArgs e)
        {

            {
                ButtonPressEventArgs information = new ButtonPressEventArgs("Button1", name , 1);
                btnPress(this, information);
            }

        }

        private void sBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Button2", name, 2);

            btnPress(this, information);
        }

        private void eBtn_Click(object sender, EventArgs e)
        {
            ButtonPressEventArgs information = new ButtonPressEventArgs("Button3", name, 3);

            btnPress(this, information);
        }

        public string fName()
        {
            return name;
        }
        #endregion 

    
        
    }
}
