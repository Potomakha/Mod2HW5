using System;
using Mod2HW5.Interfaces;
using Mod2HW5.Models;

namespace Mod2HW5.Services
{
    public class Logger : ILogger
    {
        public void Log(LogType type, string mesage)
        {
            var log = $"{DateTime.UtcNow}: {type}: {mesage}";
            Console.WriteLine(log);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }
    }
}
