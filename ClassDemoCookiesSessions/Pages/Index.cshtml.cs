using ClassDemoCookiesSessions.services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionLib.repository;
using System.Security.Claims;

namespace ClassDemoCookiesSessions.Pages
{
    public class IndexModel : PageModel
    {

        private readonly UserServices _userService;

        public IndexModel(IUserRepo repo)
        {
            _userService = new UserServices(repo);
        }



        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public void OnGet()
        {

        }
        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
                if (_userService.ValidateUser(UserName, Password))
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };
                    if (UserName == "Peter")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    }
                    // User is valid, perform login actions here
                    Response.Redirect("/session");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
        }
        

    }
}
