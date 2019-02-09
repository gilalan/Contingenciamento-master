using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class ExportVerba
    {
        public List<RelatorioCliente> RelClientes{ get; set; }
        public Verba Verba { get; set; }
        public string Periodo { get; set; }

        public ExportVerba()
        {
            this.RelClientes = new List<RelatorioCliente>();
            this.Verba = new Verba();
            this.Periodo = "";
        }
    }
}
