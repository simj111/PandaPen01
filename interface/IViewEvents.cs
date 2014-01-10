using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;
namespace Interfaces
{
    /// <summary>
    /// This is used by the views which contain button presses. It fires off the event.
    /// </summary>
    public interface IViewEvents
	{
        event ButtonPressEventHandler btnPress;
	}
}
