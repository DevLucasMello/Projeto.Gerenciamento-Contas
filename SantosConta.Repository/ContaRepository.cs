﻿using SantosConta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantosConta.Repository
{
    public class ContaRepository:IContaRepository
    {
        public void Alterar(Conta conta)
        {
            Db.Execute("ContaAlterar", conta);
        }

        public void Excluir(string id)
        {
            Db.Execute("ContaExcluir", new { Id = id });
        }

        public void Incluir(Conta conta)
        {
            Db.Execute("ContaIncluir", conta);
        }

        public ContaExibirViewModel ObterExibirPorId(string id)
        {
            return Db.QueryEntidade<ContaExibirViewModel>("ContaObterExibirPorId", new { ContaId = id });
        }

        public IEnumerable<ContaListItem> ObterPorFiltro(ContaFiltro filtro)
        {
            //if (filtro.DataInicial == DateTime.MinValue) filtro.DataInicial = DateTime.MinValue;
            //if (filtro.DataFinal == DateTime.MinValue) filtro.DataFinal = DateTime.MaxValue;

            if (filtro.DataFinal == DateTime.MinValue) filtro.DataFinal = new DateTime(2090, 12, 31);

            var lista = Db.QueryColecao<ContaListItem>("ContaObterEntreDatas",
                new
                {
                    DataInicial = filtro.DataInicial,
                    DataFinal = filtro.DataFinal,
                    IdUsuario = filtro.UsuarioId
                }).ToList();

            var listaFiltrada = lista.ToList();
            if (filtro.ContaCorrenteId != null)
            {
                listaFiltrada = listaFiltrada.ToList().Where(m => m.ContaCorrenteId == filtro.ContaCorrenteId).ToList();
            }

            if (filtro.CategoriaId != null)
            {
                listaFiltrada = listaFiltrada.ToList().Where(m => m.CategoriaId == filtro.CategoriaId).ToList();
            }
            return listaFiltrada;
        }

        public Conta ObterPorId(string id)
        {
            return Db.QueryEntidade<Conta>("ContaObterPorId", new { Id = id });
        }

        public IEnumerable<ContaListItem> ObterPorUsuario(string usuarioId)
        {
            return Db.QueryColecao<ContaListItem>("ContaObterTodos", new { IdUsuario = usuarioId });
        }

        public IEnumerable<Conta> ObterTodos(string usuarioId)
        {
            return Db.QueryColecao<Conta>("ContaObterTodos", new { Usuarioid = usuarioId });
        }

        public IEnumerable<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
