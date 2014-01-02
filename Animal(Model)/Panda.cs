﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;
using Interfaces.Events;
using BarManager;
using Interfaces.Events;
using CalculatorLibrary;

namespace AnimalModel
{
    public class Panda : IAnimalModle
    {
        
       public event FirstPassHandler fPass;
        private string _imageName = "Panda";
        private double _inHBarVal = 15;
        private double _inEBarVal = 60;
        private double _inFBarVal = 5;
        private double _happinessBarVal = 0;

        public IBarManager barmanager;
        
        public Panda(IBarManager myBarManager, ICalculate calculator)
        {
            barmanager = myBarManager;
           

            
        }

        public void FristPassSetUP()
        {
            FirstPassArgs args = new FirstPassArgs(_imageName,_inHBarVal,_inEBarVal,_inFBarVal,_happinessBarVal);
            fPass(this, args);
        }

        public IBarManager bars()
        {
      
            return barmanager;
        }

        
        //string infomation;

        //private event ButtonPressEventHandler _informationChangeEvent;

        //public void informationHandler(IAttempt1Interface obj, ButtonPressEventArgs args)
        //{
        //    infomation = args.information;
        //}

        //public void Subscribe(string eventType, ButtonPressEventHandler e)
        //{
           
        //    if (eventType == EventTypes.BUTTON_EVENT)
        //    {
        //        ButtonPressEventHandler handler = e as ButtonPressEventHandler;
        //        _informationChangeEvent += handler;

        //        //if you subscribe we will let you know immediately  
        //    }
        //    }
            
        //    //TODO add in subscribe for numerical infoamtion



        public string Name()
        {
            throw new NotImplementedException();
        }

        public void Calculate()
        {
            throw new NotImplementedException();
        }

        public void GetPicture()
        {
            throw new NotImplementedException();
        }
    }
    }
