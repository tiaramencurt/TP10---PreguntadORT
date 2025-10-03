using Microsoft.AspNetCore.Mvc;
using TP10.Models;
using Microsoft.AspNetCore.Http;

namespace TP10.Controllers
{
    public class HomeController : Controller
    {
        private Juego ObtenerJuegoDeSession()
        {
            string juegoJson = HttpContext.Session.GetString("juego");
            if (string.IsNullOrEmpty(juegoJson))
                return new Juego();
            else
                return Objeto.StringToObject<Juego>(juegoJson);
        }

        private void GuardarJuegoEnSession(Juego juego)
        {
            string juegoJson = Objeto.ObjectToString<Juego>(juego);
            HttpContext.Session.SetString("juego", juegoJson);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConfigurarJuego()
        {
            ViewBag.Categorias = BD.TraerCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Comenzar(string username, int categoria)
        {
            Juego juego = new Juego();
            juego.CargarPartida(username, categoria);
            GuardarJuegoEnSession(juego);

            ViewBag.Username = juego.Username;
            ViewBag.PuntajeActual = juego.PuntajeActual;
            ViewBag.ContadorPregunta = juego.ContadorNroPreguntaActual;
            ViewBag.PreguntaActual = juego.PreguntaActual;
            ViewBag.Respuestas = juego.ListaRespuestas;

            return View("Juego");
        }

        public IActionResult Jugar()
        {
            Juego juego = ObtenerJuegoDeSession();
            if (juego.ContadorNroPreguntaActual >= juego.ListaPreguntas.Count)
                return RedirectToAction("Fin");

            juego.PreguntaActual = juego.TraerProximaPregunta();
            juego.ListaRespuestas = juego.TraerProximasRespuestas(juego.PreguntaActual.IdPregunta);

            GuardarJuegoEnSession(juego);

            ViewBag.Username = juego.Username;
            ViewBag.PuntajeActual = juego.PuntajeActual;
            ViewBag.ContadorPregunta = juego.ContadorNroPreguntaActual;
            ViewBag.PreguntaActual = juego.PreguntaActual;
            ViewBag.Respuestas = juego.ListaRespuestas;

            return View("Juego");
        }

        [HttpPost]
public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
{
    Juego juego = ObtenerJuegoDeSession();

    // Guardar la lista de respuestas antes de avanzar
    List<Respuesta> respuestasDeLaPregunta = new List<Respuesta>(juego.ListaRespuestas);

    bool correcta = juego.VerificarRespuesta(idRespuesta);

    // Buscar la respuesta correcta en la lista guardada
    Respuesta respuestaCorrecta = null;
    foreach (Respuesta r in respuestasDeLaPregunta)
    {
        if (r.Correcta)
        {
            respuestaCorrecta = r;
            break;
        }
    }

    if (correcta)
        ViewBag.MensajeRespuesta = "¡Correcto!";
    else if (respuestaCorrecta != null)
        ViewBag.MensajeRespuesta = "Incorrecto. La correcta era: " + respuestaCorrecta.Opcion + ". " + respuestaCorrecta.Contenido;
    else
        ViewBag.MensajeRespuesta = "Incorrecto.";

    GuardarJuegoEnSession(juego);

    if (juego.ContadorNroPreguntaActual >= juego.ListaPreguntas.Count)
        return RedirectToAction("Fin");

    juego.PreguntaActual = juego.TraerProximaPregunta();
    juego.ListaRespuestas = juego.TraerProximasRespuestas(juego.PreguntaActual.IdPregunta);

    ViewBag.Username = juego.Username;
    ViewBag.PuntajeActual = juego.PuntajeActual;
    ViewBag.ContadorPregunta = juego.ContadorNroPreguntaActual;
    ViewBag.PreguntaActual = juego.PreguntaActual;
    ViewBag.Respuestas = juego.ListaRespuestas;

    return View("Juego");
}

        public IActionResult Fin()
        {
            Juego juego = ObtenerJuegoDeSession();
            ViewBag.Username = juego.Username;
            ViewBag.PuntajeFinal = juego.PuntajeActual;
            HttpContext.Session.Remove("juego"); // Limpia la partida
            return View();
        }
    }
}