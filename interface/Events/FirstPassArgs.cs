using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Events
{
    public delegate void FirstPassHandler(IAnimalModle source, FirstPassArgs args);

    public class FirstPassArgs : EventArgs
	{
        private string _imagesource;

        public string imagesource
        {
            get
            {
                return _imagesource;
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

        private double _HapnninesBar;
        public double HapnninesBar
        {
            get
            {
                return _HapnninesBar;
            }
        }


        public FirstPassArgs(string imagesource, double HBarValue, double EBarValue, double FBarValue, double HapnninesBar)
        {
            _imagesource = imagesource;
            _HBarValue = HBarValue;
            _EBarValue = EBarValue;
            _FBarValue = FBarValue;
            _HapnninesBar = HapnninesBar;
        }
	
}
}
