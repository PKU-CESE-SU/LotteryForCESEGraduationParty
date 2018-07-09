using System;
using System.IO;
namespace LotteryForCESEGraduationParty
{
    class Log
    {
        private readonly string logName = "log/log-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        private StreamWriter file = null;

        public int WriteLine(string text)
        {
            if (file == null)
            {
                if (!Directory.Exists("log/"))
                {
                    Directory.CreateDirectory("log/");
                }
                try
                {
                    file = File.CreateText(logName);
                    // 自动写入
                    file.AutoFlush = true;
                }
                catch
                {
                    return 1;
                }
            }
            try
            {
                string message = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + text;
                Console.WriteLine(message);
                file.WriteLine(message);
                return 0;
            }
            catch
            {
                return 2;
            }
        }

        public void Close()
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
}
