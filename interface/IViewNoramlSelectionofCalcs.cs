using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;

namespace Interfaces
{
    /// <summary>
    /// This is used within the CalaculationForms view and contains the event for sending of the selected calculator.
    /// </summary>
    public interface IViewNoramlSelectionofCalcs
    {
        event CalcTypeHandler selectCalc;
    }
}
