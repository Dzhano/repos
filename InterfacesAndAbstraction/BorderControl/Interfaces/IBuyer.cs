using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer
    {
        string Name { get; set; }
        int Age { get; set; }
        int Food { get; set; }

        void BuyFood();
    }
}
