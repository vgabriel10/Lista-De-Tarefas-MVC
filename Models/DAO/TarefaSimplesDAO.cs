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
    public class TarefaSimplesDAO
    {
        string connectionString = ConfigurationManager.AppSettings["sqlConnection"];

        public List<TarefaSimples> ListaDeTarefas()
        {
            List<TarefaSimples> tarefas = new List<TarefaSimples>();  
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                // Consulta SQL usando Dapper
                string sql = "SELECT * FROM Tarefas_Simples";
                var resultado = dbConnection.Query<TarefaSimples>(sql);

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
                    string sql = "DELETE * FROM Tarefas_Simples WHERE nomeTarefa = '" + nomeTarefa + "'; ";
                    dbConnection.Query(sql);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool CriarNovaTarefa(string nomeTarefa,int prioridade = 0, string previsaoConclusao = "")
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    string sql = "INSERT INTO Tarefas_Simples (nomeTarefa,prioridade,previsaoConclusao) VALUES ('"+ nomeTarefa + "',"+ prioridade + ",'"+ previsaoConclusao + "')";
                    dbConnection.Query(sql);
                }
                return true;
            }

            catch(SqlException ex)
            {
                var a = ex.Number;
                if(ex.Number == 2627)
                {
                    throw new Exception("Não foi possível criar a tarefa pois já existe uma com o mesmo nome!");
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}