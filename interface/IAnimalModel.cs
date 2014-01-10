using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces.Events;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;

namespace Interfaces
{
    /// <summary>
    /// This interface will be used by each of the Animal Classes in 
    /// </summary>
   public interface IAnimalModel
    {
        /// <summary>
    /// This interface will be used by each of the Animal Classes in 
    /// </summary>
   public interface IAnimalModel
    {
       /// <summary>
        /// First Pass a Double Array of the Intail staring Valuesues. Into trhe view module it need to pass a string repersent the Name of the Animal such as Panda   
        /// it pass the infomation as FirstPassArgs args = new FirstPassArgs(_imageName, number);
       /// 
       /// </summary>
       event FirstPassHandler fPass;
   /// <summary>
       /// This Method is used my the Controler to get The Bar Manger so it can Subscribe view to them.
       /// </summary>
       /// <returns></returns
       IButtonManager GetButtonsForSubscibe();

    
       /// <summary>
       /// Is used to get the Specifc Button Manger so that that the Wind Condtion can be subscribed to controler
       /// 
       /// </summary>
       /// <returns></returns>


       ICalculate Getcalc();
       /// <summary>
       /// is used to get the Specif Caculator so the Controller can Subscirbe to it inside the modle.
       /// </summary>
       /// <param name="_imageName"></param>
       /// <param name="ID"></param>
       /// <returns></returns>


       /// <summry>
       /// Is used to return an Invdialumodule Id which pass over from the modle these have to be defined in a string
       /// </summry>

       string Name(string _imageName, double ID);

       /// <summary>
       ///  Pass In Inatial ButtonManger Calulator and its ID all of these need to go into the datamembers Outside the filed so they can be used elsewhere.
       ///  The Tickers Will also need to be used the Ticker we use are Windowsfrom tickers.
       /// </summary>
       /// <param name="mybuttonmanager"></param>
       /// <param name="calculator"></param>
       /// <param name="ID"></param>

       void PassinInatial(IButtonManager mybuttonmanager, ICalculate calculator, int ID);



       /// <summary>
       /// Pass out an Inatial values as Doules
       /// will need somthinglike this for fullfuctionaly
       /// FirstPassArgs args = new FirstPassArgs(the name of the Animal, the numbers as a double array);
       /// fPass(this, args); 
       /// </summary>
       void FirstPassSetUP();

       /// <summary>
       /// is called from the  Button Manger
       /// And Calls the Method CaluateValues this needs the string to be passed into it for it to fuctionm
       /// </summary>
       /// <param name="Animal"></param>
       void Calculate(string Animal);     

       /// <summary>
       /// Every tick it call Calcator CaluateValues which pass in a string called decrease
       /// Also stores the Number Array results by calling the result and storing to an Array.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       void decTimer_Tick(object sender, EventArgs e);

       /// <summary>
       /// Every Tick Calls Calculator Calucate Happines which check if Happines is okay and then 
       /// Calcutor Method to get the results into the Animal modle to see if this works.
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

       void happinessTimer_Tick(object sender, EventArgs e);
       /// <summary>
       /// Simply Deactive timers when game is over
       /// </summary>

       void KillTimers();

    }
}
