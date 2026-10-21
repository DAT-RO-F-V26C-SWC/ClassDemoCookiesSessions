using ClassDemoCookiesSessions.services;
using System.Text.Json;

namespace ClassDemoCookiesSessions.util
{
    public static class KurvSessionHelper
    {
        private const string SessionKey = "Kurv";

        public static void SetKurvService(HttpContext httpContext, Kurv kurv)
        {
            string sessionContentStr = JsonSerializer.Serialize(kurv);
            httpContext.Session.SetString(SessionKey, sessionContentStr);
        }

        public static Kurv GetKurvService(HttpContext httpContext)
        {
            string? sessionContentStr = httpContext.Session.GetString(SessionKey);
            Kurv? kurv =  sessionContentStr != null ? JsonSerializer.Deserialize<Kurv>(sessionContentStr) : null;

            return kurv ?? new Kurv();
        }
    }
}