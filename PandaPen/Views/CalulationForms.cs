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
        int CatchthenumberID;
        public event CalcTypeHandler selectCalc;

        public CalulationForms(int ID)
        {
            CatchthenumberID = ID;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcTypeArgs information = new CalcTypeArgs(comboBox1.Text,CatchthenumberID);
            selectCalc(this, information);
        }
    }
}
