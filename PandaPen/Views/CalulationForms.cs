using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Interfaces;
using System.Windows.Forms;
using Interfaces.Events;

namespace PandaPen
{
    public partial class CalulationForms : Form , IViewNoramlSelectionofCalcs
    {
        public CalulationForms()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcTypeArgs information = new CalcTypeArgs(comboBox1.Text);
            selectCalc(this, information);
        }
    
public event Interfaces.Events.CalcTypeHandler  selectCalc;
}
}
