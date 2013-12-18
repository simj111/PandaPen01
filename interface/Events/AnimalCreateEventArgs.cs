using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void AnimalCreateEventHandler(System.Windows.Forms.Button source, AnimalCreateEventArgs args);

    class AnimalCreateEventArgs
	{

	}
}
