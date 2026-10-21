using ClassDemoCookiesSessions.services;
using ClassDemoCookiesSessions.util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassDemoCookiesSessions.Pages.session
{
    public class ShowKurvModel : PageModel
    {
        public Kurv Kurv { get; set; }
        public void OnGet()
        {
            Kurv = KurvSessionHelper.GetKurvService(HttpContext);
        }
        public void OnPostPlus(int id)
        {
            Kurv = KurvSessionHelper.GetKurvService(HttpContext);
            Kurv.AddCountToVare(id, 1);
            KurvSessionHelper.SetKurvService(HttpContext, Kurv);
        }
        public void OnPostMinus(int id)
        {
            Kurv = KurvSessionHelper.GetKurvService(HttpContext);
            Kurv.ReduceCountFromVare(id, 1);
            KurvSessionHelper.SetKurvService(HttpContext, Kurv);
        }
    }
}
