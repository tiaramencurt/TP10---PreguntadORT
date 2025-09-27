using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TP10.Models
{
    public static class BD
    {
        //private static string _connectionString = @"Server=localhost; DataBase=PreguntadOrt; Integrated Security=True; TrustServerCertificate=True;";
        private static string _connectionString = @"Server=localhost\SQLEXPRESS;Database=PreguntadOrt;Trusted_Connection=True;Integrated Security=True; TrustServerCertificate=True;";

        
        public static List<Categoria> TraerCategorias()
        {
            List<Categoria> lista;
            string query = "SELECT * FROM Categorias";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                lista = connection.Query<Categoria>(query).ToList();
            }
            return lista;
        }

        public static List<Pregunta> TraerPreguntas(int IdCategoria)
        {
            List<Pregunta> lista;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                if (IdCategoria == -1)
                {
                    string query = "SELECT * FROM Preguntas";
                    lista = connection.Query<Pregunta>(query).ToList();
                }
                else
                {
                    string query = "SELECT * FROM Preguntas WHERE IdCategoria = @PIdCategoria";
                    lista = connection.Query<Pregunta>(query, new { PIdCategoria = IdCategoria }).ToList();
                }
            }
            return lista;
        }

        public static List<Respuesta> TraerRespuestas(int IdPregunta)
        {
            List<Respuesta> lista;
            string query = "SELECT * FROM Respuestas WHERE IdPregunta = @PIdPregunta";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                lista = connection.Query<Respuesta>(query, new { PIdPregunta = IdPregunta }).ToList();
            }
            return lista;
        }
    }
}
