using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void PassCalcResultsHandler(IAnimalModle source, PassCalcResultsArgs args);

    public class PassCalcResultsArgs : EventArgs
    {

        private double _HappinesBar;

        public double HappinesBar
        {

            get
            {
                return _HappinesBar;
            }
        
         }
   

        private double _HBarValue;

        public double HBarValue
        {
            get
            {
                return _HBarValue;
            }
        }


        private double _EBarValue;

        public double EBarValue
        {
            get
            {
                return _EBarValue;
            }
        }


        private double _FBarValue;

        public double FBarValue
        {
            get
            {
                return _FBarValue;
            }
        }



        public PassCalcResultsArgs(double HBarValue, double EBarValue, double FBarValue, double HappinesBar)
        {
            _HBarValue = HBarValue;
            _EBarValue = EBarValue;
            _FBarValue = FBarValue;
        }
    }
}
	

