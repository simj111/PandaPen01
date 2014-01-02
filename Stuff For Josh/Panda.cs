using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using interfaces.Events;
using interfaces.Interface;

namespace Animal_Model
{
    public class Panda : IAnimalModle
    {
        string infomation;

        private event ButtonPressEventHandler _informationChangeEvent;

        public void informationHandler(IAttempt1Interface obj, ButtonPressEventArgs args)
        {
            infomation = args.information;
        }

        public void Subscribe(string eventType, ButtonPressEventHandler e)
        {
           
            if (eventType == EventTypes.BUTTON_EVENT)
            {
                ButtonPressEventHandler handler = e as ButtonPressEventHandler;
                _informationChangeEvent += handler;

                //if you subscribe we will let you know immediately  
            }
            }
            
            //TODO add in subscribe for numerical infoamtion

        }
    }
