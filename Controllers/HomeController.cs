using Microsoft.AspNetCore.Mvc;
using TP10.Models;

namespace TP10.Controllers
{
    public class HomeController : Controller
    {
        private Juego TraerJuegoSesion()
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
            Juego juego = TraerJuegoSesion();
            ViewBag.Categorias = juego.TraerCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Comenzar(string username, int categoria)
        {
            Juego juego = TraerJuegoSesion();
            juego.CargarPartida(username, categoria);
            GuardarJuegoSesion(juego);
            return RedirectToAction("Jugar");
        }

        public IActionResult Jugar()
        {
            Juego juego = TraerJuegoSesion();
            Pregunta pregunta = juego.TraerProximaPregunta();

            if (pregunta == null)
            {
                GuardarJuegoSesion(juego);
                return View("Fin");
            }

            ViewBag.Username = juego.Username;
            ViewBag.PuntajeActual = juego.PuntajeActual;
            ViewBag.ContadorPregunta = juego.ContadorNroPreguntaActual;
            ViewBag.PreguntaActual = pregunta;
            ViewBag.Respuestas = juego.TraerProximasRespuestas(pregunta.IdPregunta);

            GuardarJuegoSesion(juego);
            return View();
        }

        [HttpPost]
        public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
        {
            Juego juego = TraerJuegoSesion();
            bool correcta = juego.VerificarRespuesta(idRespuesta);

            Respuesta correctaObj = juego.ListaRespuestas.Find(r => r.Correcta);

            ViewBag.Correcta = correcta;
            ViewBag.RespuestaCorrecta = correctaObj.Contenido;

            GuardarJuegoSesion(juego);
            return View("Respuesta");
        }

        public IActionResult Fin()
        {
            Juego juego = TraerJuegoSesion();

            ViewBag.Username = juego.Username;
            ViewBag.PuntajeFinal = juego.PuntajeActual;

            HttpContext.Session.Remove("juego");

            return View();
        }
    }
}
