using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Galoresoft.Diagnostics;

namespace LoggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bind OnLog Event
            Log.OnLog += Log_OnLog;

            Log.Write("Test A: ({0}", DateTime.Now);
            Log.Write(")<NewLine>");

            Log.WriteLine();
            Log.WriteLine("*");

            //Unbind OnLog Event
            Log.OnLog -= Log_OnLog;

            Log.WriteLine("Test B");

            Console.ReadKey();
        }

        private static void Log_OnLog(string message)
        {
            Console.Write(message);
        }
    }
}
