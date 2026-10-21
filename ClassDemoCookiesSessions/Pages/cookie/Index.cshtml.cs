using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoCookiesSessions.Pages.cookie
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public String?  Name { get; set; }
        public void OnGet()
        {
            // henter fra cookie
            Name = Request.Cookies["Name"];
        }

        public void OnPost()
        {
            if (Name != null)
            {
                // gemmer i cookie
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddHours(2)
                };
                Response.Cookies.Append("Name", Name, cookieOptions);
            }
        }

        

    }
}
