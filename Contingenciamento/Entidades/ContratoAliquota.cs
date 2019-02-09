using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.Entidades
{
    public class ContratoAliquota
    {
        public ContratoAliquota() { }
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Contrato Contrato { get; set; }
        public Verba Verba { get; set; }
        public double Aliquota { get; set; }
        public int Ano { get; set; }

        public ContratoAliquota(int id, Cliente cliente, Contrato contrato, Verba verba, double aliquota, int ano)
        {
            this.Id = id;
            this.Cliente = cliente;
            this.Contrato = contrato;
            this.Verba = verba;
            this.Aliquota = aliquota;
            this.Ano = ano;
        }
    }
}
