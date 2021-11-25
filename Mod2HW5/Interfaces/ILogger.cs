using Mod2HW5.Models;

namespace Mod2HW5.Interfaces
{
    public interface ILogger
    {
        public void LogInfo(string message);
        public void LogError(string message);
        public void LogWarning(string message);
        public void Log(LogType type, string mesage);
    }
}
