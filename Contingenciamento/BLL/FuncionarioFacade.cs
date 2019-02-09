using System;
using System.Collections.Generic;
using Contingenciamento.Entidades;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirFuncionario(Funcionario funcionario)
        {
            this._funcionarioDAO.Insert(funcionario);
        }

        public void UpdateFuncionario(int id, Funcionario funcionario)
        {
            this._funcionarioDAO.Update<int>(id, funcionario);
        }

        public Funcionario GetFuncionario(int id)
        {
            return this._funcionarioDAO.Get<int>(id);
        }

        public Funcionario GetFuncionarioByMatricula(string matriculation)
        {
            return this._funcionarioDAO.GetByMatricula<string>(matriculation);
        }

        public List<Funcionario> GetTopFuncionario()
        {
            return this._funcionarioDAO.GetTop();
        }

        public void DeleteFuncionario(int id)
        {
            this._funcionarioDAO.Delete<int>(id);
        }

        public void InserirFuncionarioList(HashSet<Funcionario> funcList)
        {
            this._funcionarioDAO.BulkInsert(funcList);
        }

        public System.Windows.Forms.AutoCompleteStringCollection GetNomesFuncionarios()
        {
            return this._funcionarioDAO.GetNomesFuncionarios();
        }       
    }
}
