using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using System.Globalization;

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
                DateTime? previsaoConclusaoConvertida = null;
                string dataFormatada = string.Empty;
                string formatoEntrada = "dd/MM/yyyy";
                if (previsaoConclusao != string.Empty)
                {
                    try
                    {
                        //var dia = int.Parse(previsaoConclusao.Substring(0, 2));
                        //var mes = int.Parse(previsaoConclusao.Substring(3, 2));
                        //var ano = int.Parse(previsaoConclusao.Substring(6, 4));
                        //previsaoConclusaoConvertida = new DateTime(ano, mes, dia);

                        var dia = previsaoConclusao.Substring(0, 2);
                        var mes = previsaoConclusao.Substring(3, 2);
                        var ano = previsaoConclusao.Substring(6, 4);
                        dataFormatada = string.Concat(ano,"/",mes,"/",dia);
                        DateTime dataTeste = DateTime.ParseExact(dataFormatada, "yyyy/MM/dd", CultureInfo.InvariantCulture);

                        

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Data inválida!");
                    }
                    
                    //previsaoConclusao = DateTime.ParseExact(previsaoConclusao, formatoEntrada, System.Globalization.CultureInfo.InvariantCulture);
                }
                using (IDbConnection dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    string sql = "INSERT INTO Tarefas_Simples (nomeTarefa,prioridade,previsaoConclusao) VALUES ('"+ nomeTarefa + "',"+ prioridade + ",'"+ dataFormatada + "')";
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
                throw new Exception(ex.Message);
            }
        }
    }
}