using Exercise.Appenders;
using Exercise.Layouts;
using Exercise.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Друг тест / Another test
            
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;
            var logger = new Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");*/

            File.Delete("../../../log.txt");
            
            List<IAppender> appenders = new List<IAppender>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                IAppender newAppender = null;
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                ILayout layout = null;
                switch (data[1])
                {
                    case "SimpleLayout":
                        layout = new SimpleLayout();
                        break;
                    case "XmlLayout":
                        layout = new XmlLayout();
                        break;
                }

                switch (data[0])
                {
                    case "ConsoleAppender":
                        newAppender = new ConsoleAppender(layout);
                        break;
                    case "FileAppender":
                        ILogFile logFile = new LogFile();
                        newAppender = new FileAppender(layout, logFile);
                        break;
                }

                ReportLevel reportLevel = ReportLevel.Info;
                if (data.Length == 3) reportLevel = CheckReportLevel(data[2]);
                newAppender.ReportLevel = reportLevel;

                appenders.Add(newAppender);
            }

            Logger logger = new Logger(appenders.ToArray());

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] execute = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                ReportLevel reportLevel = CheckReportLevel(execute[0]);
                string time = execute[1];
                string message = execute[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        logger.Info(time, message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(time, message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(time, message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(time, message);
                        break;
                    case ReportLevel.Fatal:
                        logger.Fatal(time, message);
                        break;
                }

                /*foreach (IAppender appender in appenders)
                    appender.Append(time, reportLevel, message);*/
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in appenders) Console.WriteLine(appender);
        }

        static ReportLevel CheckReportLevel(string level)
        {
            switch (level)
            {
                case "INFO":
                    return ReportLevel.Info;
                case "WARNING":
                    return ReportLevel.Warning;
                case "ERROR":
                    return ReportLevel.Error;
                case "CRITICAL":
                    return ReportLevel.Critical;
                case "FATAL":
                    return ReportLevel.Fatal;
                default:
                    return ReportLevel.Info;
            }
        }
    }
}
