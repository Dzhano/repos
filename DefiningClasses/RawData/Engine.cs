using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        private int power;
        private int speed;

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
