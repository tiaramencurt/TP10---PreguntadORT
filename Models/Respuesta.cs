using Newtonsoft.Json;

namespace TP10.Models
{
    public class Respuesta
    {
        [JsonProperty]
        public int IdRespuesta { get; private set; }

        [JsonProperty]
        public int IdPregunta { get; private set; }

        [JsonProperty]
        public string Opcion { get; private set; }

        [JsonProperty]
        public string Contenido { get; private set; }

        [JsonProperty]
        public bool Correcta { get; private set; }

        [JsonProperty]
        public string Foto { get; private set; }
        public Respuesta() { }
        public Respuesta(int idRes, int idPreg, string opcion, string contenido, bool correcta, string foto)
        {
            IdRespuesta = idRes;
            IdPregunta = idPreg;
            Opcion = opcion;
            Contenido = contenido;
            Correcta = correcta;
            Foto = foto;
        }
    }
}
