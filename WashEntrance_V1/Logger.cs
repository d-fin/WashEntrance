using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WashEntrance_V1
{
    public static class Logger
    {
        public static readonly object lock_File = new object();

        public static string PromptForLogFilePath()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                saveFileDialog.Title = "Select a Log File Location";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }

        public static void UpdateLogPathInConfig(string logPath)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["logPath"].Value = logPath;
            config.Save(ConfigurationSaveMode.Modified);

           ConfigurationManager.RefreshSection("appSettings");
        }

        public static bool DoesLogPathExist()
        {
            return File.Exists(GetLogFilePathFromConfig());
        }
        public static string GetLogFilePathFromConfig()
        {
            return ConfigurationManager.AppSettings["logPath"];
        }

        public static void WriteLog(string message)
        {
            string logPath = GetLogFilePathFromConfig();
            try
            {
                lock (lock_File)
                {
                    using (StreamWriter writer = new StreamWriter(logPath, true))
                    {
                        writer.WriteLine($"{DateTime.Now} : {message}");
                    }
                }
            }
            catch (Exception) { }
        }

        public static void LogThreadCreation(Thread thread)
        {
            string logMessage = $"Thread Creation" +
                                $"\tThread ID: {thread.ManagedThreadId}\n" +
                                $"\tThread Name: {thread.Name ?? "N/A"}\n" +
                                $"\tStart Time: {DateTime.Now}\n" +
                                $"\tThread State: {thread.ThreadState}\n";
                              

            WriteLog(logMessage);
        }

        public static void LogThreadTermination(Thread thread)
        {
            string logMessage = $"Thread Termination" +
                                $"\tThread ID: {thread.ManagedThreadId}\n" +
                                $"\tThread Name: {thread.Name ?? "N/A"}\n" +
                                $"\tTermination Time: {DateTime.Now}\n" +
                                $"\tThread State: {thread.ThreadState}";
                                

            WriteLog(logMessage);
        }

        public static void DeleteOldLines()
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            int keepLines = 10000;

            try
            {
                lock (lock_File)
                {
                    string[] lines = File.ReadAllLines(logPath);

                    if (lines.Length > keepLines)
                    {
                        int linesToDelete = lines.Length - keepLines;
                        List<string> newLines = lines.Skip(linesToDelete).ToList();
                        File.WriteAllLines(logPath, newLines);
                    }
                }
            }
            catch (FileNotFoundException) { }                
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"You need to change the directory info in the code! Contact David!!!", "Error");
            }
            catch (Exception) { }
        }
    }
}
