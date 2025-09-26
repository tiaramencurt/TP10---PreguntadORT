using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
namespace TP10.Models
{
    public class Categoria
    {
        [JsonProperty]
        public int IdCategoria { get; private set; }
        [JsonProperty]
        public string Nombre { get; private set; }
        [JsonProperty]
        public string Foto { get; private set; }
        public Categoria() { }
        public Categoria(int id, string nombre, string foto)
        {
            IdCategoria = id;
            Nombre = nombre;
            Foto = foto;
        }

    }
}