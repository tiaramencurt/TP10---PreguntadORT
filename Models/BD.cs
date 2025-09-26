using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace TP10.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=PreguntadOrt;Integrated Security=True;TrustServerCertificate=True;";

        public static List<Categoria> ObtenerCategorias()
        {
            List<Categoria> lista;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Categorias";
                lista = db.Query<Categoria>(sql).AsList();
            }
            return lista;
        }

        public static List<Pregunta> ObtenerPreguntas(int categoria)
        {
            List<Pregunta> lista;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                if (categoria == -1)
                {
                    string sql = "SELECT * FROM Preguntas";
                    lista = db.Query<Pregunta>(sql).AsList();
                }
                else
                {
                    string sql = "SELECT * FROM Preguntas WHERE IdCategoria = @pIdCategoria";
                    lista = db.Query<Pregunta>(sql, new { pIdCategoria = categoria }).AsList();
                }
            }
            return lista;
        }

        public static List<Respuesta> ObtenerRespuestas(int idPregunta)
        {
            List<Respuesta> lista;
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                lista = db.Query<Respuesta>(sql, new { pIdPregunta = idPregunta }).AsList();
            }
            return lista;
        }
    }
}
