using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interfaces.Events
{
    public delegate void CalcTypeHandler(Form source, CalcTypeArgs args);

    public class CalcTypeArgs : EventArgs
    {
        private string _calcTypes;

        public string calcTypes
        {
            get
            {
                return _calcTypes;
            }
        }

        private int _ID;
        public int ID
        {
            get
            {
                return _ID;
            }

        }

 

        public CalcTypeArgs(string calcTypes, int ID)
        {
            _ID = ID;
            _calcTypes = calcTypes;
        }
    }
}
