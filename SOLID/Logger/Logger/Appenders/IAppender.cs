using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        void Append(string date, ReportLevel reportLevel, string message);
    }
}
