using System;
using System.IO;
using Mod2HW5.Interfaces;
using Mod2HW5.Models;
using Newtonsoft.Json;

namespace Mod2HW5.Services
{
    public class Logger : ILogger
    {
        private readonly IMessageWriter _messageWriter;
        public Logger(IMessageWriter messageWriter)
        {
            _messageWriter = messageWriter;
        }

        public void Log(LogType type, string mesage)
        {
            var log = $"{DateTime.UtcNow}: {type}: {mesage}";
            Console.WriteLine(log);
            _messageWriter.Write(mesage);
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
