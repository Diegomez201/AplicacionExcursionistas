#region Usings
using AplicacionExcursionistas.Modelo;
using AplicacionExcursionistas.Servicios;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace AplicacionExcursionistas.Controllers
{
    public class HomeController : Controller
    {
        #region Variables locales
        private readonly RiesgoMejorado _optimizador = new();
        #endregion

        #region Peticion HttpGet para Index Consulta Modelo y Servicio
        [HttpGet]
        public IActionResult Index()
        {
            return View(new EscRiesgo());
        }

        [HttpPost]
        public IActionResult Index(EscRiesgo request)
        {
            var resultado = _optimizador.EncontrarCombinacionOptima(request);
            ViewBag.Resultado = resultado;
            return View(request);
        }
        #endregion
    }
}