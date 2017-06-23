using System;
using System.IO;

namespace nvcore
{
    public static class LogFile
    {

        /// <summary>
        /// Write a new line to the local log file.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <param name="src"></param>
        /// <param name="msg"></param>
        public static async void UpdateLogfile(string file, string type, string src, string msg)
        {
            if (!File.Exists(file)) File.Create(file);

            try
            {
                using (FileStream aFile = new FileStream(file, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(aFile))
                    {
                        await sw.WriteLineAsync("Type: " + type + " # Soruce: " + src + " # Time: " + DateTime.Now + " # Message: " + msg);
                    }
                }
            }
            catch (IOException)
            {
            }
        }
    }
}
