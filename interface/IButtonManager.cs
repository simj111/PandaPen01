﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interfaces.Events;

namespace Interfaces
{
	public interface IButtonManager
	{
        void Subscribe(Form f);
        void CheckIfValid(Form f, ButtonPressEventArgs args);
        void ConnectANIMAL(IAnimalModel LINKEDANIMAL , string Name);
        void PassOutCalucaltion(string Clacualtion);
        void Unsubscribe(Form f);
	}
}
