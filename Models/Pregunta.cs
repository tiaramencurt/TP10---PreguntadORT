using Newtonsoft.Json;

namespace TP10.Models
{
    public class Pregunta
    {
        [JsonProperty]
        public int IdPregunta { get; private set; }

        [JsonProperty]
        public int IdCategoria { get; private set; }

        [JsonProperty]
        public string Enunciado { get; private set; }

        [JsonProperty]
        public string Foto { get; private set; }
        public Pregunta() { }
        public Pregunta(int id, int idCat, string enunciado, string foto)
        {
            IdPregunta = id;
            IdCategoria = idCat;
            Enunciado = enunciado;
            Foto = foto;
        }
    }
}
