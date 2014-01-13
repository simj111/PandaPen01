using System;
using Interfaces.Events;

namespace Interfaces
{
    /// <summary>
    /// This is used within the CalaculationForms view and contains the event for sending of the selected calculator.
    /// </summary>
    public interface IViewNormalSelectionofCalcs
    {
        event CalcTypeHandler selectCalc;
    }
}
