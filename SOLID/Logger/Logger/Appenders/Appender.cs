using Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Appenders
{
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;
        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        protected int MessagesCount { get; set; }

        protected bool CheckReportLevel(ReportLevel reportLevel)
        {
            return reportLevel < ReportLevel;
        }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {layout.GetType().Name}, " +
                $"Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesCount}";
        }
    }
}
