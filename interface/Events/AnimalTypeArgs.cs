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
        public string _animalTypes;

        public string animalTypes
        {
            get
            {
                return _animalTypes;
            }
        }
        public AnimalTypeArgs(string animalTypes)
        {
            _animalTypes = animalTypes;
        }
	}
}
