using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Attribute
    {
        public double baseValue;
        public double currentValue;

        public double maxValue;
        public double minValue;

        public double regenerationValue;

        public Attribute() { }

        public void Decrease(double decreaseValue)
        {
            if (currentValue > decreaseValue) 
            {
                if (currentValue - decreaseValue > minValue)
                { 
                currentValue -= decreaseValue;
                }
                else currentValue = minValue; 
            }
            else { currentValue = minValue; }
        }

        public void Gain(double gainValue) 
        {
            if (currentValue + gainValue < maxValue) { currentValue += gainValue; }
            else { currentValue = maxValue; }
        }

        public void Regeneration() // must be called each tick  ???
        {
            if (currentValue + regenerationValue < maxValue)
            {
                currentValue += regenerationValue;
            }
            else currentValue = maxValue;
        }

        public void SetBaseValue()
        {
            currentValue = baseValue;
        }

        public void SetMaxValue()
        {
            currentValue = maxValue;
        }

        public void SetMinValue()
        {
            currentValue = minValue;
        }


    }


}
