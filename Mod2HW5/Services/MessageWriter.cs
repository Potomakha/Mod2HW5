using System;
using Mod2HW5.Interfaces;

namespace Mod2HW5.Services
{
    public class MessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine("тут будет запись в файл, и не только)");
        }
    }
}
