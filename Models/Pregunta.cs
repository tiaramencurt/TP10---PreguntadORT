using System;

namespace TP10.Models
{
    public class Pregunta
    {
        [JsonProperty]
        public int IdPregunta { get; private set; }
        public int IdCategoria { get; private set; }
        public string Enunciado { get; private set; }
        public string Foto { get; private set; }
    }
}
