using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exercise.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";

        public int Size => File.ReadAllText(FilePath)
            .Where(c => char.IsLetter(c)).Sum(c => c);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
