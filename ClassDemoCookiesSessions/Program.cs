using SessionLib.model;
using SessionLib.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

IVarerRepo varerRepo = new VarerRepo();

#if DEBUG
varerRepo.Add(new Vare(1, "Kaj Kage", 14.0));
varerRepo.Add(new Vare(2, "Vaniljekrans", 22.0));
varerRepo.Add(new Vare(3, "Snegl", 18.0));
varerRepo.Add(new Vare(4, "Lagkage", 90.0));
varerRepo.Add(new Vare(5, "Brunsviger", 24.0));
#endif

builder.Services.AddSingleton<IVarerRepo>(varerRepo);

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ClassDemoCookiesSessions.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
