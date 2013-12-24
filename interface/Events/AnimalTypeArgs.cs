using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void AnimalTypeHandler(string source, AnimalTypeArgs args);

    class AnimalTypeArgs : EventArgs
	{
        public string _animalType;

        public string animalType
        {
            get
            {
                return _animalType;
            }
        }
	}
}
