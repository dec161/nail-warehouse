using NailWarehouse.DatabaseStorage;
using NailWarehouse.Entities.Models;
using NailWarehouse.EntityManager;
using NailWarehouse.EntityManager.Contracts;
using NailWarehouse.MemoryStorage.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider
            .SetValueMustBeANumberAccessor(fieldName => $"Поле '{fieldName}' должно содержать число.");
        options.ModelBindingMessageProvider
            .SetValueMustNotBeNullAccessor(_ => $"Поле не должно быть пустым.");
    });
builder.Services.AddScoped<IStorage<Nail>, NailDatabaseStorage>();
builder.Services.AddScoped<INailManager, NailManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
