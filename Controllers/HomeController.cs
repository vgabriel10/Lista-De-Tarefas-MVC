using ListaDeTarefasMVC.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var listaTarefas = new TarefaDAO().ListaDeTarefas();
            var listaTarefas = new TarefaSimplesDAO().ListaDeTarefas();
            ViewBag.ListaDeTarefas = listaTarefas;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public void RegistrarTarefaConcluida(string nomeTarefa)
        {
            var listaDeTarefasConcluidas = nomeTarefa.Split(',');
            foreach(var tarefa in listaDeTarefasConcluidas)
            {
                var registrouTarefa = new TarefaConcluidaDAO().RegistrarTarefaConcluida(tarefa);
            }
            
        }
    }
}