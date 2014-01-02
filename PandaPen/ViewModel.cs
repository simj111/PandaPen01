using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;

namespace PandaPen
{
    class ViewModel
    {
        private View VM = null; 
        
        public ViewModel( View Modle)
        {
            VM = Modle;
        }

        public void Subscribe(IAnimalModle source)
        {

            source.fPass += new FirstPassHandler(CheckIfValid);
        }
        public void CheckIfValid(IAnimalModle source, FirstPassArgs args)
        {
            //gotthereInTheEND
            int alpa = 1;
        }



    }
}
