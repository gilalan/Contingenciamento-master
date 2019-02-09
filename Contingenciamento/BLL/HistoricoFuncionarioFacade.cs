using System;
using System.Collections.Generic;
using Contingenciamento.Entidades;

namespace Contingenciamento.BLL
{
    public partial class Facade
    {
        public void InserirHistoricoFuncionario(HistoricoFuncionario historicoFuncionario)
        {
            this._historicoFuncionarioDAO.Insert(historicoFuncionario);
        }

        public void UpdateHistoricoFuncionario(int id, HistoricoFuncionario historicoFuncionario)
        {
            this._historicoFuncionarioDAO.Update<int>(id, historicoFuncionario);
        }

        public HistoricoFuncionario GetHistoricoFuncionario(int id)
        {
            return this._historicoFuncionarioDAO.Get<int>(id);
        }

        public List<HistoricoFuncionario> GetTopHistoricoFuncionario()
        {
            return this._historicoFuncionarioDAO.GetTop();
        }

        public List<HistoricoFuncionario> GetHistoricoByDatas(DateTime start, DateTime end)
        {
            return this._historicoFuncionarioDAO.GetHistoricoByDatas(start, end);
        }

        public List<HistoricoFuncionario> GetHistoricoByFuncAndDatas(int funcId, DateTime inicio, DateTime fim)
        {
            return this._historicoFuncionarioDAO.GetHistoricoByFuncAndDatas(funcId, inicio, fim);
        }

        public List<HistoricoFuncionario> GetHistoricoByClienteAndDatas(int clienteId, DateTime inicio, DateTime fim)
        {
            return this._historicoFuncionarioDAO.GetHistoricoByClienteAndDatas(clienteId, inicio, fim);
        }

        public List<HistoricoFuncionario> GetHistoricoByContratoAndDatas(int clienteId, int contratoId, DateTime inicio, DateTime fim)
        {
            return this._historicoFuncionarioDAO.GetHistoricoByContratoAndDatas(clienteId, contratoId, inicio, fim);
        }

        public void DeleteHistoricoFuncionario(int id)
        {
            this._historicoFuncionarioDAO.Delete<int>(id);
        }

        public void InserirHistoricoFuncionarioList(List<HistoricoFuncionario> funcList)
        {
            this._historicoFuncionarioDAO.BulkInsert(funcList);
        }
    }
}
