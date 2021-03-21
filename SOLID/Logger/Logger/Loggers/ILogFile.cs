using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Loggers
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string content);
    }
}
