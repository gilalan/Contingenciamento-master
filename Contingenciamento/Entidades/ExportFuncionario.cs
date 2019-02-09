using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class ExportFuncionario
    {
        public Funcionario Funcionario { get; set; }
        public List<RelatorioFunc> RelFuncionarios { get; set; }
        public Verba Verba { get; set; }
        public string Periodo { get; set; }

        public ExportFuncionario()
        {
            this.Funcionario = new Funcionario();
            this.RelFuncionarios = new List<RelatorioFunc>();
            this.Verba = new Verba();
            this.Periodo = "";
        }
    }
}
