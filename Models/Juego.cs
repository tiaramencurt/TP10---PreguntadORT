using Newtonsoft.Json;
using System.Collections.Generic;

namespace TP10_PreguntadOrt.Models
{
    public class Juego
    {
        [JsonProperty]
        public string Username { get; private set; }

        [JsonProperty]
        public int PuntajeActual { get; private set; }

        [JsonProperty]
        public int CantidadPreguntasCorrectas { get; private set; }

        [JsonProperty]
        public int ContadorNroPreguntaActual { get; private set; }

        [JsonProperty]
        public Pregunta PreguntaActual { get; private set; }

        [JsonProperty]
        public List<Pregunta> ListaPreguntas { get; private set; }

        [JsonProperty]
        public List<Respuesta> ListaRespuestas { get; private set; }

        private void InicializarJuego()
        {
            Username = "";
            PuntajeActual = 0;
            CantidadPreguntasCorrectas = 0;
            ContadorNroPreguntaActual = 0;
            PreguntaActual = null;
            ListaPreguntas = null;
            ListaRespuestas = null;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return BD.ObtenerCategorias();
        }

        public void CargarPartida(string username, int categoria)
        {
            InicializarJuego();
            Username = username;
            ListaPreguntas = BD.ObtenerPreguntas(categoria);
            ContadorNroPreguntaActual = 0;
            if (ListaPreguntas.Count > 0)
            {
                PreguntaActual = ListaPreguntas[0];
                ListaRespuestas = BD.ObtenerRespuestas(PreguntaActual.IdPregunta);
            }
        }

        public Pregunta ObtenerProximaPregunta()
        {
            if (ContadorNroPreguntaActual < ListaPreguntas.Count)
            {
                PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
                return PreguntaActual;
            }
            else
            {
                return null;
            }
        }

        public List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
        {
            ListaRespuestas = BD.ObtenerRespuestas(idPregunta);
            return ListaRespuestas;
        }

        public bool VerificarRespuesta(int idRespuesta)
        {
            bool resultado = false;
            foreach (Respuesta r in ListaRespuestas)
            {
                if (r.IdRespuesta == idRespuesta)
                {
                    resultado = r.Correcta;
                    if (resultado)
                    {
                        PuntajeActual += 10; // puntos por acierto
                        CantidadPreguntasCorrectas++;
                    }
                }
            }
            ContadorNroPreguntaActual++;
            if (ContadorNroPreguntaActual < ListaPreguntas.Count)
            {
                PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
                ListaRespuestas = BD.ObtenerRespuestas(PreguntaActual.IdPregunta);
            }
            else
            {
                PreguntaActual = null;
            }
            return resultado;
        }
    }
}
