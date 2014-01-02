using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IViewModel
    {
        void ConvertResults(double HBarValue, double EBarValue, double FBarValue);
        void Subscribe ();
        void SendResults();

    }
}
