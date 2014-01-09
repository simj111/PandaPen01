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
        public string _calcTypes;

        public string calcTypes
        {
            get
            {
                return _calcTypes;
            }
        }
        public CalcTypeArgs(string calcTypes)
        {
            _calcTypes = calcTypes;
        }
    }
}
