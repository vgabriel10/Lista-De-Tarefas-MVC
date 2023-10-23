using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace ListaDeTarefasMVC.Models.DAO
{
    public class TarefaDAO
    {
        string connectionString = ConfigurationManager.AppSettings["sqlConnection"];

        public List<Tarefa> ListaDeTarefas()
        {
            List<Tarefa> tarefas = new List<Tarefa>();  
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                // Consulta SQL usando Dapper
                string sql = "SELECT * FROM Tarefas";
                var resultado = dbConnection.Query<Tarefa>(sql);
                //IEnumerable<Tarefa> usuarios = dbConnection.Query<Tarefa>(sql);

                foreach (var tarefa in resultado)
                {
                    tarefas.Add(tarefa);
                }
            }

            return tarefas;
        }
    }
}