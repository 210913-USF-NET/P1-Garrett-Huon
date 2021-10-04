using System;
using Serilog;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("../logs/log.txt",
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Hello, Serilog!");

            new LoginMenu().Start();
            Log.Information("Goodbye, Serilog!");
            Log.CloseAndFlush();
        }

    }
}
