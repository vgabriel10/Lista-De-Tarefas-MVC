using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaDeTarefasMVC.Models
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public DateTime DataConclusao { get; set; }

    }
}