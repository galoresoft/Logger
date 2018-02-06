using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using System.Runtime.CompilerServices;

namespace Galoresoft.Diagnostics
{
    public static class Log
    {
        //public delegate void CallbackHandler(string message);
        public static event Action<string> OnLog;
        
        public static string FileName { get; set; }

        static void DoLog(string message)
        {
            OnLog?.Invoke(message);
        }
        
        static Log()
        {
            FileName = null;
        }

        /// <summary>
        /// Write raw text, excluding timestamp.
        /// </summary>
        /// <param name="message">String.Format-like text.</param>
        /// <param name="args"></param>
        public static void Write(string message, params object[] args)
        {
            try
            {
                string tmpmessage = string.Format(message, args);
                File.AppendAllText(FileName ?? string.Format("{0:yyyy-MM-dd}.log", DateTime.Now), tmpmessage);

#if DEBUG
                Debug.WriteLine(tmpmessage);
#endif
                OnLog?.Invoke(tmpmessage);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Write text and it's timestamp, ending with a new line.
        /// </summary>
        /// <param name="message">String.Format-like text.</param>
        /// <param name="args"></param>
        public static void WriteLine(string message = null, params object[] args)
        {
            try
            {
                string tmpmessage = string.IsNullOrEmpty(message) ? string.Empty : DateTime.Now.ToString("yyy-MM-dd HH:mm:ss ") + string.Format(message ?? string.Empty, args);
                File.AppendAllText(FileName ?? string.Format("{0:yyyy-MM-dd}.log", DateTime.Now), tmpmessage + Environment.NewLine);

#if DEBUG
                Debug.WriteLine(tmpmessage);
#endif
                OnLog?.Invoke(tmpmessage);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }


    }
}
