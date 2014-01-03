using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces.Events;

namespace Interfaces
{
	public interface IBarManager
	{
        void Subscribe(IViewEvents f);
        void CheckIfValid(Form f, ButtonPressEventArgs args);
        void ConnectANIMAL(IAnimalModle LINKEDANIMAL);
	}
}
