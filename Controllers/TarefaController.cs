using ListaDeTarefasMVC.Models.DAO;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
    public class TarefaController : Controller
    {
        public ActionResult Index()
        {
            var listaTarefas = new TarefaSimplesDAO().ListaDeTarefas();
            ViewBag.ListaDeTarefas = listaTarefas;

            var tarefasConcluidas = new TarefaConcluidaDAO().TarefasConcluidas();
            ViewBag.TarefasConcluidas = tarefasConcluidas;
            return View();
        }

        public void ExibirTarefasConcluidas()
        {
            var tarefasConcluidas = new TarefaConcluidaDAO().TarefasConcluidas();
            ViewBag.TarefasConcluidas = tarefasConcluidas;
        }

        public ActionResult NovaTarefa()
        {
            return View();
        }

        [HttpPost]
        public void CriarNovaTarefa(string nome,int prioridade,string previsaoConclusao)
        {
            try
            {
                var criarTarefa = new TarefaSimplesDAO().CriarNovaTarefa(nome, prioridade, previsaoConclusao);


                ViewBag.Message = "Deu certo!";
                TempData["ok"] = "Tarefa criada com sucesso!";
                Response.Redirect("/Tarefa/NovaTarefa");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                TempData["erro"] = ex.Message;
                Response.Redirect("/Tarefa/NovaTarefa");
            } 
        }

        [HttpPost]
        public void RegistrarTarefaConcluida(string nomeTarefa)
        {
            var listaDeTarefasConcluidas = nomeTarefa.Split(',');
            foreach (var tarefa in listaDeTarefasConcluidas)
            {
                var registrouTarefa = new TarefaConcluidaDAO().RegistrarTarefaConcluida(tarefa);
            }
            ExcluirTarefas(listaDeTarefasConcluidas);
        }
        
        public void ExcluirTarefas(Array tarefas)
        {
            foreach (string tarefa in tarefas)
            {
                var registrouTarefa = new TarefaConcluidaDAO().RemoverTarefa(tarefa);
            }
        }
    }
}