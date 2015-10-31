using System;
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
        where D: DbContext
    {
        #region Atributos

        private D conexao;

        #endregion

        #region Construtores
        public RepositorioPai(D contexto)
        {
            this.conexao = contexto;
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
        #endregion
    }
}
