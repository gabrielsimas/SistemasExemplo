﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contrato.Comum;

namespace Infraestrutura.ORM.EF.Repositorio.Comum
{
    public class RepositorioPai<T,D>
        :IRepositorioPai<T>
        where T: class
        where D: DbContext,IUnitOfWork
    {
        #region Atributos

        private D conexao;
        public D Conexao
        {
            get
            {
                return conexao;
            }

            set
            {
                conexao = value;
            }
        }

        #endregion

        #region Construtores
        public RepositorioPai(D contexto)
        {
            this.conexao = contexto;
            conexao.Database.Log = Console.Write;
        }

        #endregion

        #region Métodos do Repositório
        public ICollection<T> BuscarTodos()
        {
            return conexao.Set<T>().AsNoTracking().ToList();
        }

        public void Criar(T entidade)
        {
            conexao.Entry(entidade).State = EntityState.Added;
        }

        public void Editar(T entidade)
        {
            conexao.Entry(entidade).State = EntityState.Modified;
        }

        public void Excluir(T entidade)
        {
            
            conexao.Entry(entidade).State = EntityState.Deleted;
        }

        public ICollection<T> FiltrarCompostoPor(Func<T, bool> predicado)
        {
            return this.conexao.Set<T>().AsNoTracking().Where(predicado).ToList();
        }

        public T FiltrarSimplesPor(Func<T, bool> predicado)
        {
            return this.conexao.Set<T>().AsNoTracking().Where(predicado).SingleOrDefault();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void CommitAlteracoes()
        {
            conexao.CommitAlteracoes();
        }

        public void CommitaERefresha()
        {
            conexao.CommitaERefresha();
        }

        public void DesfazAlteracoes()
        {
            conexao.DesfazAlteracoes();
        }
        #endregion        
    }
}
