using Microsoft.AspNetCore.Mvc;
using NailWarehouse.MvcApp.Models;
using System.Diagnostics;

namespace NailWarehouse.MvcApp.Controllers;

/// <summary>
/// Контроллер для главной страницы.
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    /// Отображает главную страницу.
    /// </summary>
    public IActionResult Index()
    {
        return View();
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
