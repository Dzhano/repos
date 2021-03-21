using System;
using Exercise.Layouts;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (CheckReportLevel(reportLevel)) return;

            Console.WriteLine(string.Format(this.layout.Template, date, reportLevel.ToString().ToUpper(), message));
            MessagesCount++;
        }
    }
}
