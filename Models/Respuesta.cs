using Newtonsoft.Json;

namespace TP10.Models
{
    public class Respuesta
    {
        [JsonProperty]
        public int IdRespuesta { get; set; }

        [JsonProperty]
        public int IdPregunta { get; set; }

        [JsonProperty]
        public string Opcion { get; set; }

        [JsonProperty]
        public string Contenido { get; set; }

        [JsonProperty]
        public bool Correcta { get; set; }

        [JsonProperty]
        public string Foto { get; set; }
        public Respuesta() { }
        public Respuesta(int idPreg, string opcion, string contenido, bool correcta, string foto)
        {
            IdPregunta = idPreg;
            Opcion = opcion;
            Contenido = contenido;
            Correcta = correcta;
            Foto = foto;
        }
    }
}
