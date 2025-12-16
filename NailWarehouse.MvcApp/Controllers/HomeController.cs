using Microsoft.AspNetCore.Mvc;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.MvcApp.Models;
using System.Diagnostics;

namespace NailWarehouse.MvcApp.Controllers;

/// <summary>
/// Контроллер для главной страницы.
/// </summary>
public class HomeController(INailManager nailManager) : Controller
{
    private const string NailFormViewName = "NailForm";

    private INailManager NailManager { get; } = nailManager;

    /// <summary>
    /// Отображает главную страницу.
    /// </summary>
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var statisticsTask = NailManager.GetStatistics(cancellationToken);
        var nailsTask = NailManager.GetAll(cancellationToken);

        var model = new IndexViewModel()
        {
            Nails = await nailsTask,
            Statistics = await statisticsTask
        };

        return View(model);
    }

    /// <summary>
    /// Отображает форму для добавления нового <see cref="Nail"/>.
    /// </summary>
    [HttpGet]
    public IActionResult Add()
    {
        var viewModel = new NailFormViewModel()
        {
            PageTitle = "Добавление"
        };

        return View(NailFormViewName, viewModel);
    }

    /// <summary>
    /// Проверяет и добавляет созданный <see cref="Nail"/>
    /// в базу данных.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Add(NailFormViewModel viewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(NailFormViewName, viewModel);
        }

        var nail = new Nail()
        {
            Name = viewModel.Name,
            Size = new(viewModel.Diameter, viewModel.Length),
            Material = viewModel.Material,
            Amount = viewModel.Amount,
            MinAmount = viewModel.MinAmount,
            Price = viewModel.Price
        };
        await NailManager.Add(nail, cancellationToken);

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Отображает форму для редактирования существующего <see cref="Nail"/>.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        if (await NailManager.Get(id, cancellationToken) is not Nail nail)
        {
            return RedirectToAction(nameof(Index));
        }

        var viewModel = new NailFormViewModel()
        {
            PageTitle = "Изменение",
            Id = nail.Id,
            Name = nail.Name,
            Diameter = nail.Size.Diameter,
            Length = nail.Size.Length,
            Material = nail.Material,
            Amount = nail.Amount,
            MinAmount = nail.MinAmount,
            Price = nail.Price
        };

        return View(NailFormViewName, viewModel);
    }

    /// <summary>
    /// Проверяет и сохраняет результат редактирования.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Edit(NailFormViewModel viewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid || viewModel.Id is not Guid id)
        {
            return View(NailFormViewName, viewModel);
        }

        var nail = new Nail()
        {
            Id = id,
            Name = viewModel.Name,
            Size = new(viewModel.Diameter, viewModel.Length),
            Material = viewModel.Material,
            Amount = viewModel.Amount,
            MinAmount = viewModel.MinAmount,
            Price = viewModel.Price
        };
        await NailManager.Update(nail, cancellationToken);

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Удаляет существующий <see cref="Nail"/>
    /// из базы данных.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Remove(Guid id, CancellationToken cancellationToken)
    {
        if (await NailManager.Get(id, cancellationToken) is Nail nail)
        {
            await NailManager.Remove(nail, cancellationToken);
        }

        return RedirectToAction(nameof(Index));
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
