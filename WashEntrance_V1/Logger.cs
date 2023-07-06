using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashEntrance_V1
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now} - {message}");
            }
        }

        public static void DeleteOldLines()
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            int keepLines = 1000;

            string[] lines = File.ReadAllLines(logPath);

            if (lines.Length > keepLines)
            {
                int linesToDelete = lines.Length - keepLines;
                List<string> newLines = lines.Skip(linesToDelete).ToList();
                File.WriteAllLines(logPath, newLines);
            }
        }
    }
}
