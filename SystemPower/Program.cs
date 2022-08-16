using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemPower
{
    /// <summary>
    /// This is the Main method class
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            BatteryReader batteryReader = new BatteryReader();
            batteryReader.CheckBattery();
        }
    }
    /// <summary>
    /// This is the publisher class
    /// </summary>
    internal class PowerCheck 
    {
        public delegate void NotifyHandler();
        public event NotifyHandler NotifyOtherClasses;

        /// <summary>
        /// The Battery Reading is initiated
        /// </summary>
        public void BatteryReading()
        {
            int BatteryLevel = 100;
            for (int i = BatteryLevel; i > 0; i-=10)
            {
                if (i < 30)
                {
                    OnLowBattery();
                }
                Console.WriteLine("The Battery Level is " + i);


            }
            
        }
        /// <summary>
        /// Called/raised when [low battery].
        /// </summary>
        protected virtual void OnLowBattery()
        {
            NotifyOtherClasses?.Invoke();  
        }

    }
    /// <summary>
    /// This is the subscriber class
    /// </summary>
    public class BatteryReader   
    {
        public void CheckBattery()
        {
            var accAn = new PowerCheck();
            accAn.NotifyOtherClasses += BatteryReadingProcess;
           

            accAn.BatteryReading();
        }


        /// <summary>
        /// Notifies the user on low battery.
        /// </summary>
        public void BatteryReadingProcess()
        {
            Console.WriteLine("Your battery Level is low, kindly recharge");
            Console.ReadLine();
        }
    }
}
