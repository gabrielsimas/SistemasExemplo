using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces.Base;
using ArtigoUnity.Infraestrutura.EF.Repositorio.Interfaces;

namespace ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao
{
    public class RepositorioBase<T,D>
        :IRepositorioBase<T>
        where T: EntidadeBase
        where D: DbContext,IUnitOfWork,IDisposable
    {
        #region Atributos
        private D conexao;
        #endregion

        #region Construtores
        public RepositorioBase(D contexto)
        {
            this.conexao = contexto;
        }
        #endregion

        #region Métodos do Repositorio

        public void Salvar(T entidade)
        {
            conexao.Entry(entidade).State = EntityState.Added;
        }

        public T BuscarPorId(long? id)
        {
            return conexao.Set<T>().Find(id);
        }

        public ICollection<T> BuscarTodos()
        {
            return conexao.Set<T>().ToList();
        }

        public T FiltrarUmPor(Func<T, bool> predicado)
        {
            return conexao.Set<T>().Where(predicado).Single();
        }

        public ICollection<T> FiltrarVariosPor(Func<T, bool> predicado)
        {
            return conexao.Set<T>().Where(predicado).ToList();
        }
        
        public ICollection<T> BuscarTodos(int pageIndex, int pageCount)
        {
            return conexao.Set<T>().ToList().Skip(pageCount * pageIndex).Take(pageCount).ToList();
        }

        public ICollection<T> FiltrarVariosPor(Func<T, bool> predicado, int pageIndex, int pageCount)
        {
            return conexao.Set<T>().Where(predicado).ToList().Skip(pageCount * pageIndex).Take(pageCount).ToList();            
        }

        public void Alterar(T entidade)
        {
            conexao.Entry(entidade).State = EntityState.Modified;
        }               
        public void Exclui>r(T entidade)
        {
            conexao.Entry(entidade).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            conexao.Dispose();
        }
        #endregion

        #region Unit Of Work

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
