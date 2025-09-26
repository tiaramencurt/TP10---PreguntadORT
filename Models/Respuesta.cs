using System;
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
        public int Opcion { get; set; }
        [JsonProperty]
        public string Contenido { get; set; }
        [JsonProperty]
        public bool Correcta { get; set; }
        [JsonProperty]
        public string Foto { get; set; }
    }
}
