using Newtonsoft.Json;

namespace TP10.Models
{
    public class Pregunta
    {
        [JsonProperty]
        public int IdPregunta { get; set; }

        [JsonProperty]
        public int IdCategoria { get; set; }

        [JsonProperty]
        public string Enunciado { get; set; }

        [JsonProperty]
        public string Foto { get; set; }
        public Pregunta() { }
        public Pregunta(int idCat, string enunciado, string foto)
        {
            IdCategoria = idCat;
            Enunciado = enunciado;
            Foto = foto;
        }
    }
}
