using Microsoft.Extensions.Logging;
using NailWarehouse.App.UI;
using NailWarehouse.EntityManager;
using NailWarehouse.EntityManager.Infrastructure;
using NailWarehouse.MemoryStorage;
using Serilog;

namespace NailWarehouse.App;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var nails = new ListStorage();

        var serilogger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.File("log.txt", outputTemplate:
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        var loggerFactory = new LoggerFactory()
            .AddSerilog(serilogger);

        var logger = loggerFactory.CreateLogger<TimedNailManager>();

        var nailManager = new NailManager(nails)
            .WithPerformanceLogging(logger);

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(nailManager));
    }
}