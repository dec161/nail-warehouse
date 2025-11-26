using NailWarehouse.App.UI;
using NailWarehouse.EntityManager;
using NailWarehouse.MemoryStorage;

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
        var nailManager = new NailManager(nails);

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm(nailManager));
    }
}