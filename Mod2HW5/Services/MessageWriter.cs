using System;
using System.IO;
using Mod2HW5.Interfaces;
using Newtonsoft.Json;

namespace Mod2HW5.Services
{
    public class MessageWriter : IMessageWriter
    {
        private readonly DirectoryInfo _directoryInfo;
        private StreamWriter _streamWriter;

        public MessageWriter()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);

            OperationSystem = config.OperationSystem;
            LoggerFilesNum = config.LoggerFilesNum;
            LoggerDirName = config.LoggerDirName;

            var dirPath = Directory.GetCurrentDirectory() + "\\" + LoggerDirName;
            _directoryInfo = new DirectoryInfo(dirPath);
            _directoryInfo.Create();
            FilePath = _directoryInfo.FullName + $"\\{DateTime.UtcNow.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
        }

        ~MessageWriter()
        {
        }

        public string OperationSystem { get; init; }
        public int LoggerFilesNum { get; init; }
        public string LoggerDirName { get; init; }
        public string FilePath { get; set; }

        public void Write(string message)
        {
            ChekDir();
            var newPath = _directoryInfo.FullName + $"\\{DateTime.UtcNow.ToString("hh.mm.ss dd.MM.yyyy")}.txt";
            if (_streamWriter == null)
            {
                _streamWriter = new StreamWriter(newPath, true);
            }

            try
            {
                if (!FilePath.Equals(newPath))
                {
                    FilePath = newPath;
                    _streamWriter.Close();
                    _streamWriter = new StreamWriter(FilePath, true);
                }

                _streamWriter.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ChekDir()
        {
            var files = _directoryInfo.GetFiles();
            foreach (var item in files)
            {
                if (files.Length > LoggerFilesNum)
                {
                    File.Delete(item.FullName);
                }

                return;
            }
        }
    }
}
