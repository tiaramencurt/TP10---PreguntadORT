using Microsoft.AspNetCore.Mvc;
using TP10.Models;

namespace TP10.Controllers
{
    public class HomeController : Controller
    {
        private Juego ObtenerJuegoSesion()
        {
            if (HttpContext.Session.GetString("juego") == null)
            {
                return new Juego();
            }
            return Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        }

        private void GuardarJuegoSesion(Juego juego)
        {
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfigurarJuego()
        {
            Juego juego = ObtenerJuegoSesion();
            ViewBag.Categorias = juego.ObtenerCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Comenzar(string username, int categoria)
        {
            Juego juego = ObtenerJuegoSesion();
            juego.CargarPartida(username, categoria);
            GuardarJuegoSesion(juego);
            return RedirectToAction("Jugar");
        }

        public IActionResult Jugar()
        {
            Juego juego = ObtenerJuegoSesion();
            Pregunta pregunta = juego.ObtenerProximaPregunta();

            if (pregunta == null)
            {
                GuardarJuegoSesion(juego);
                return View("Fin");
            }

            ViewBag.Username = juego.Username;
            ViewBag.PuntajeActual = juego.PuntajeActual;
            ViewBag.ContadorPregunta = juego.ContadorNroPreguntaActual;
            ViewBag.PreguntaActual = pregunta;
            ViewBag.Respuestas = juego.ObtenerProximasRespuestas(pregunta.IdPregunta);

            GuardarJuegoSesion(juego);
            return View();
        }

        [HttpPost]
        public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
        {
            Juego juego = ObtenerJuegoSesion();
            bool correcta = juego.VerificarRespuesta(idRespuesta);

            Respuesta correctaObj = juego.ListaRespuestas.Find(r => r.Correcta);

            ViewBag.Correcta = correcta;
            ViewBag.RespuestaCorrecta = correctaObj.Contenido;

            GuardarJuegoSesion(juego);
            return View("Respuesta");
        }

        public IActionResult Fin()
        {
            Juego juego = ObtenerJuegoSesion();

            ViewBag.Username = juego.Username;
            ViewBag.PuntajeFinal = juego.PuntajeActual;

            // Reiniciar juego en sesión
            HttpContext.Session.Remove("juego");

            return View();
        }
    }
}
