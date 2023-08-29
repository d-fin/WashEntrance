﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WashEntrance_V1
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            try
            {
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now} : {message}");
                }
            }
            catch (Exception e)
            {
                
            }
            
        }

        public static void DeleteOldLines()
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            int keepLines = 500;

            try
            {
                string[] lines = File.ReadAllLines(logPath);
                
                if (lines.Length > keepLines)
                {
                    int linesToDelete = lines.Length - keepLines;
                    List<string> newLines = lines.Skip(linesToDelete).ToList();
                    File.WriteAllLines(logPath, newLines);
                }
            }
            catch (FileNotFoundException)
            {
                File.Create(logPath).Close();

            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"You need to change the directory info in the code! Contact David!!!", "Error");
            }
        }
    }
}
