using Microsoft.AspNetCore.Mvc;
using TP05.Models;

namespace TP05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Comenzar()
        {
            Escape.IniciarJuego();
            int estadoJuego = Escape.GetEstadoJuego();
            SetHabitacionViewData(estadoJuego);
            return View("Habitacion", new { id = estadoJuego });
        }

        public IActionResult Habitacion(int id, string respuesta)
        {
            int estadoJuego = Escape.GetEstadoJuego();
            if (id != estadoJuego)
            {
                return RedirectToAction("Habitacion", new { id = estadoJuego });
            }

            if (Escape.ResolverSala(id, respuesta))
            {
                if (id == 4)
                {
                    return RedirectToAction("Victoria");
                }
                id++;
                SetHabitacionViewData(id);
                return View("Habitacion", new { id = id });
            }
            else
            {
                SetHabitacionViewData(id);
                ViewBag.Error = "Clave incorrecta, intenta de nuevo.";
                return View("Habitacion");
            }
        }

        public IActionResult Victoria()
        {
            ViewBag.Apoyo = Escape.GetApoyo();
            ViewBag.TiempoTotal = Escape.GetTiempoTotal();
            return View();
        }

        public IActionResult Tutorial()
        {
            return View();
        }

        public IActionResult Creditos()
        {
            return View();
        }

        public IActionResult UsarPista(int id)
        {
            Escape.UsarPista();
            SetHabitacionViewData(id);
            return View("Habitacion", new { id = id });
        }

        private void SetHabitacionViewData(int id)
        {
            int estadoJuego = Escape.GetEstadoJuego();
            int idPista = 2 * (estadoJuego - 1);

            ViewData["Title"] = $"Habitación {id}";
            ViewData["Description"] = Escape.GetDescripcion(id);
            ViewData["Image"] = $"/desafio{id}.png";
            ViewData["Action"] = Url.Action("Habitacion", new { id = id });
            ViewData["Pista1"] = Escape.Pistas[idPista];
            ViewData["Pista2"] = Escape.Pistas[idPista + 1];
            ViewData["Apoyo"] = Escape.GetApoyo();
            ViewData["TiempoRestante"] = 1200 - Escape.GetTiempoTotal();
        }
    }
}