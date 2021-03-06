﻿using System;
using System.Windows.Forms;
using Interfaces.Events;

namespace Interfaces
{
    /// <summary>
    /// This interface is used to validate button presses and is not used within MEF.
    /// </summary>
	public interface IButtonManager
	{
        /// <summary>
        /// Subscribes the Button subscribes to the View .
        /// </summary>
        /// <param name="f"></param>
        void Subscribe(Form f);
        void CheckIfValid(Form f, ButtonPressEventArgs args);
        void ConnectANIMAL(IAnimalModel LINKEDANIMAL , string Name);
        void PassOutCalculation(string Calculation);
        void Unsubscribe(IAnimalViews f);
	}
}
