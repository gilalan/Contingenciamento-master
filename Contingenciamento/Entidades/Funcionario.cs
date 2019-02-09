using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingenciamento.Entidades
{
    public class Funcionario 
    {
        public Funcionario() { }

        public int Id { get; set; }
        public int IdSoll { get; set; }
        public string Name { get; set; }
        public string Matriculation { get; set; }
        public string Pis { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataRescisao { get; set; }

        public Funcionario(int id, int idSoll, string name, string matriculation, string pis, string cpf, DateTime dataAdmissao, DateTime dataRescisao)
        {
            this.Id = id;
            this.IdSoll = idSoll;
            this.Name = name;
            this.Matriculation = matriculation;
            this.Pis = pis;
            this.Cpf = cpf;
            this.DataAdmissao = dataAdmissao;
            this.DataRescisao = dataRescisao;
        }

        public Funcionario(int id, int idSoll, string name, string matriculation, DateTime dataAdmissao, DateTime dataRescisao)
        {
            this.Id = id;
            this.IdSoll = idSoll;
            this.Name = name;
            this.Matriculation = matriculation;
            this.DataAdmissao = dataAdmissao;
            this.DataRescisao = dataRescisao;
        }

        public Funcionario(int idSoll, string name, string matriculation, DateTime dataAdmissao, DateTime dataRescisao)
        {
            this.IdSoll = idSoll;
            this.Name = name;
            this.Matriculation = matriculation;
            this.DataAdmissao = dataAdmissao;
            this.DataRescisao = dataRescisao;
        }

        public Funcionario(string matriculation, string name, DateTime dataAdmissao, DateTime dataRescisao)
        {
            this.Matriculation = matriculation;
            this.Name = name;
            this.DataAdmissao = dataAdmissao;
            this.DataRescisao = dataRescisao;
        }

        public void copyInfo(Funcionario fromFunc)
        {
            this.DataRescisao = fromFunc.DataRescisao;
        }

        public override bool Equals(Object obj)
        {
            Funcionario personObj = obj as Funcionario;
            if (personObj == null)
                return false;
            else
                return personObj.Matriculation == this.Matriculation;
        }

        public override int GetHashCode()
        {
            int codigo = Convert.ToInt32(this.Matriculation);            
            return codigo.GetHashCode();
        }

    }

    class FuncionarioComparer : IEqualityComparer<Funcionario>
    {
        public bool Equals(Funcionario x, Funcionario y)
        {
            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return x.Matriculation == y.Matriculation;
        }

        public int GetHashCode(Funcionario obj)
        {
            // Stores the result.
            int codigo = Convert.ToInt32(obj.Matriculation);
            //int result = 0;

            // Don't compute hash code on null object.
            if (obj == null)
            {
                return 0;
            }

            return codigo;
        }
    }
}
