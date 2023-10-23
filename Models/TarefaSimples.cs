using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaDeTarefasMVC.Models
{
    public class TarefaSimples
    {
        public string NomeTarefa { get; set; }
        public int Prioridade { get; set; }
        public DateTime PrevisaoConclusao { get; set; }

    }
}