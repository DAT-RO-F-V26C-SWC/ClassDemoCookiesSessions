using Microsoft.AspNetCore.Authentication.Cookies;
using SessionLib.model;
using SessionLib.repository;
using System.Security.Cryptography;
using System.Text;

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

IUserRepo userRepo = new UserRepo();
#if DEBUG
using (SHA256 mySHA256 = SHA256.Create())
{
    byte[] hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes("Secret"));
    userRepo.Add(new User("Peter", hash));

    hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes("Hemlig"));
    userRepo.Add(new User("Jakob", hash));
}
#endif

builder.Services.AddSingleton<IUserRepo>(userRepo);


builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ClassDemoCookiesSessions.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.IsEssential = true;
});


//
// for settinig up claims based authentication with cookies, we need to add the following code to the Program.cs file:
//
builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true; 
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/Index";

});

builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/admin/NyVare");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
