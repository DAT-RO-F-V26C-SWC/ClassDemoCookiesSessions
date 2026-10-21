using ClassDemoCookiesSessions.services;
using ClassDemoCookiesSessions.util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SessionLib.model;
using SessionLib.repository;

namespace ClassDemoCookiesSessions.Pages.session
{
    public class IndexModel : PageModel
    {
        // instans felter
        private readonly IVarerRepo _repo;

        public List<Vare> Varer { get; set; }


        // constructor
        public IndexModel(IVarerRepo repo)
        {
            _repo = repo;
            //Varer = new List<VareWithCount>();
        }
        public void OnGet()
        {
            Varer = _repo.GetAll();
        }

        public void OnPost(int id)
        {
            Kurv _kurv = KurvSessionHelper.GetKurvService(HttpContext);
            try
            {
                Vare vare = _repo.Get(id);
                _kurv.AddVare(new VareWithCount(vare.Id, vare.Name, vare.Price, 1));
                // husk at gemme i session
                KurvSessionHelper.SetKurvService(HttpContext, _kurv);
            }
            catch (KeyNotFoundException knfe)
            {
                // do something
            }
            Varer = _repo.GetAll();
        }

        public IActionResult OnPostKurv()
        {
            return RedirectToPage("ShowKurv");
        }
    }
}
