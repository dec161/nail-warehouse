using Microsoft.AspNetCore.Mvc;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.MvcApp.Models;
using System.Diagnostics;

namespace NailWarehouse.MvcApp.Controllers;

/// <summary>
/// Контроллер для главной страницы.
/// </summary>
public class HomeController(INailManager nailManager) : Controller
{
    private CancellationTokenSource CancellationTokenSource { get; } = new();

    private INailManager NailManager { get; } = nailManager;

    /// <summary>
    /// Отображает главную страницу.
    /// </summary>
    public async Task<IActionResult> Index()
    {
        var statisticsTask = NailManager.GetStatistics(CancellationTokenSource.Token);
        var nailsTask = NailManager.GetAll(CancellationTokenSource.Token);

        var model = new IndexViewModel()
        {
            Nails = await nailsTask,
            Statistics = await statisticsTask
        };

        return View(model);
    }

    /// <summary>
    /// Отображает страницу ошибки.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
