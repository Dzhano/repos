using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public interface IEmployee
    {
        string Name { get; set; }
        void PrintData();
    }
}
