using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DigitalClock
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class numberDisplay
    {
        private int limit;
        private int value;

        public numberDisplay(int rollOverLimit)
        {
            limit = rollOverLimit;
            value = 0;
        }

        public void Increment()
        {
            /* if (value == limit -1)
             {
                 value = 0;
             }
             else
                 value++; 
              This will work   
              */

            value = (value + 1) % limit;
        }

        public string PrintValue()
        {
            if (value < 10)
            {
                return "0" + value;
            }
            else
                return value.ToString();
        }

        public void SetValue(int replaceValue)
        {
            if ((replaceValue >= 0) && replaceValue < limit)
                value = replaceValue;
        }

        public int getValue()
        {
            return value;
        }

        public class ClockDisplay
        {
            numberDisplay hours;
            numberDisplay minutes;
            string DisplayString;

            public ClockDisplay()
            {
                hours = new numberDisplay(24);
                minutes = new numberDisplay(60);

                UpdateDisplay();
            }
            public ClockDisplay(int hour, int minute)
            {
                hours = new numberDisplay(24);
                minutes = new numberDisplay(60);
                setTime(hour, minute);
            }


            void UpdateDisplay()
            {
                DisplayString = hours.PrintValue() + ":" + minutes.PrintValue();
            }

            void setTime(int hour, int minute)
            {
                hours.SetValue(hour);
                minutes.SetValue(minute);
            }

            public void timeTick()
            {
                minutes.Increment();
                if(minutes.getValue() == 0)
                {
                    hours.Increment();
                }
                UpdateDisplay();
            }
        }
    }
}
