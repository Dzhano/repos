using Exercise.Layouts;
using Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exercise.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (CheckReportLevel(reportLevel)) return;

            string content = string.Format(this.layout.Template, date, reportLevel.ToString().ToUpper(), message) + Environment.NewLine;
            this.logFile.Write(content);
            MessagesCount++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {logFile.Size}";
        }
    }
}
