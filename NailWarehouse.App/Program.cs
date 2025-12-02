using Microsoft.Extensions.Logging;
using NailWarehouse.App.UI;
using NailWarehouse.EntityManager;
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
            .WriteTo.Seq("http://localhost:5341", apiKey: "9X4paYuhVmlYVgaMpWdo")
            .CreateLogger();

        var loggerFactory = new LoggerFactory()
            .AddSerilog(serilogger);

        var logger = loggerFactory.CreateLogger<NailManager>();

        var nailManager = new NailManager(nails, logger);

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(nailManager));
    }
}