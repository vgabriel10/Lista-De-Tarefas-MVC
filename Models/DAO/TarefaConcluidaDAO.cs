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
    public class TarefaConcluidaDAO
    {
        string connectionString = ConfigurationManager.AppSettings["sqlConnection"];

        public List<TarefaConcluida> TarefasConcluidas()
        {
            List<TarefaConcluida> tarefas = new List<TarefaConcluida>();
            DateTime dataAtual = DateTime.Now;
            string dataAtualFormatada = dataAtual.ToString("yyyy/MM/dd");
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                // Consulta SQL usando Dapper
                string sql = "SELECT * FROM Tarefas_Concluidas WHERE DataConclusao BETWEEN '" + dataAtualFormatada + " 00:00:00' AND '" + dataAtualFormatada + " 23:59:59';";
                var resultado = dbConnection.Query<TarefaConcluida>(sql);

                foreach (var tarefa in resultado)
                {
                    tarefas.Add(tarefa);
                }
            }

            return tarefas;
        }

        public bool RemoverTarefa(string nomeTarefa)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();

                    // Consulta SQL usando Dapper
                    string sql = "DELETE FROM Tarefas_Simples WHERE nomeTarefa = '" + nomeTarefa.Trim() + "'; ";
                    dbConnection.Query(sql);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool RegistrarTarefaConcluida(string nomeTarefa)
        {
            DateTime dataAtual = DateTime.Now;
            string dataAtualFormatada = dataAtual.ToString("yyyy/MM/dd HH:mm:ss");
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();

                    // Consulta SQL usando Dapper
                    string sql = "INSERT INTO Tarefas_Concluidas (NomeTarefa,DataConclusao) VALUES ('" + nomeTarefa.Trim() + "','"+ dataAtualFormatada + "');";
                    dbConnection.Query(sql);

                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}