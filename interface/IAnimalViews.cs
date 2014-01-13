using System;
using Interfaces.Events;
namespace Interfaces
{
    /// <summary>
    /// This is used by the views which contain button presses. It fires off the event.
    /// </summary>
    public interface IAnimalViews
	{
        event ButtonPressEventHandler btnPress;
        string fName();
	}
}
