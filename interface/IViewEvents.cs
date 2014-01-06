using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;
namespace Interfaces
{
    public interface IThreeBarViewEvents
	{
        event ButtonPressEventHandler btnPress;
        
	}
}
