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
            return View();
        }

        public IActionResult Comenzar()
        {
            int estadoJuego = Escape.GetEstadoJuego();
            SetHabitacionViewData(estadoJuego);
            return View("Habitacion", new { id = Escape.GetEstadoJuego() });
        }



        public IActionResult Habitacion(int id, string respuesta)
        {            int estadoJuego = Escape.GetEstadoJuego();

            int idPista = 2 * (estadoJuego - 1);
            Console.WriteLine(Escape.Pistas[idPista]);
            Console.WriteLine(Escape.Pistas[idPista +1]);

            if (id != Escape.GetEstadoJuego())
            {
                return RedirectToAction("Habitacion", new { id = Escape.GetEstadoJuego() });

            }

            if (Escape.ResolverSala(id, respuesta))
            {
                if (id == 4)
                {
                    return RedirectToAction("Victoria");
                }
                return RedirectToAction("Habitacion", new { id = id + 1 });
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

        private void SetHabitacionViewData(int id)
        {
            int idPista = 2 * (Escape.EstadoJuego - 1);
            Console.WriteLine(Escape.Pistas[idPista]);
            Console.WriteLine(Escape.Pistas[idPista +1]);
            switch (id)
            {
                case 1:
                    ViewData["Title"] = "Habitación 1";
                    ViewData["Description"] = "Entras último a la casa y no conoces a nadie, al principio te fulminan y quedas en placa, pero te llaman al confe para demostrar porque tenes que quedarte, y salis primero de placa. Hay 5 jugadores.";
                    ViewData["Image"] = "/desafio1.png";
                    ViewData["Action"] = Url.Action("Habitacion", new { id = 1 });
                    break;
                case 2:
                    ViewData["Title"] = "Habitación 2";
                    ViewData["Description"] = "A la siguiente semana, jugas la prueba del líder para ganar la inmunidad. Elige un jugador para salvar. Hay 4 jugadores.";
                    ViewData["Image"] = "/desafio2.png";
                    ViewData["Action"] = Url.Action("Habitacion", new { id = 2 });
                    break;
                case 3:
                    ViewData["Title"] = "Habitación 3";
                    ViewData["Description"] = "Suena el teléfono y atendes, tienes la oportunidad de cenar con un familiar y que te de información sobre a quién sacar si completas un desafío.";
                    ViewData["Image"] = "/desafio3.png";
                    ViewData["Action"] = Url.Action("Habitacion", new { id = 3 });
                    ViewData["Pista1"] = Escape.Pistas[idPista];
                    break;
                case 4:
                    ViewData["Title"] = "Habitación 4";
                    ViewData["Description"] = "Gracias a esto pudiste salir último de placa y llegar a la final. Hay 3 jugadores. Tienes que conseguir la mayor cantidad de votos posibles. El jugador con mayor índice de apoyo va a ganar.";
                    ViewData["Image"] = "/desafio4.png";
                    ViewData["Action"] = Url.Action("Habitacion", new { id = 4 });
                    break;
                default:
                    RedirectToAction("Index");
                    break;
            }
        }
    }
}
