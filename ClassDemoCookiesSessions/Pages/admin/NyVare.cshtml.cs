using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionLib.repository;

namespace ClassDemoCookiesSessions.Pages.admin
{
    [Authorize(Roles = "admin")]
    public class NyVareModel : PageModel
    {
        private readonly IVarerRepo _repo;


        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Navn { get; set; }

        [BindProperty]
        public double Price { get; set; }


        public NyVareModel(IVarerRepo repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _repo.Add(new SessionLib.model.Vare(Id, Navn, Price));
                TempData["Message"] = $"Vare {Navn} er oprettet";
                Response.Redirect("/session/Index");
            }
            else
            {
                TempData["Message"] = "Fejl i indtastning";
            }
        }
    }
}
