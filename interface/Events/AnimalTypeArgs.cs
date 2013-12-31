using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interfaces.Events
{

    public delegate void AnimalTypeHandler(Form source, AnimalTypeArgs args);

    public class AnimalTypeArgs : EventArgs
	{
        public string _animalType;

        public string animalType
        {
            get
            {
                return _animalType;
            }
        }
        public AnimalTypeArgs(string animalType)
        {
            _animalType = animalType;
        }
	}
}
