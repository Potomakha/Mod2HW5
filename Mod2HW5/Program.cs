using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Mod2HW5.Interfaces;
using Mod2HW5.Services;
using Newtonsoft.Json;

namespace Mod2HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<Logger>()
                .AddTransient<IActions, ActionService>()
                .AddTransient<ILogger, Logger>()
                .AddTransient<IMessageWriter, MessageWriter>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
            var start = serviceProvider.GetService<Starter>();
            start.Run();
        }
    }
}
