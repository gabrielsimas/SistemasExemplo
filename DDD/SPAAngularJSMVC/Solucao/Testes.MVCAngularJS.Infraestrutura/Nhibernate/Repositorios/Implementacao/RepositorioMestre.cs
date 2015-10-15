using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Configuracao;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao
{
    public class RepositorioMestre<T>: IRepositorioMestre<T>
        where T: class
    {
        #region Atributos

        private NhibernateUtil unitOfWork;        
        protected ISession Sessao
        {
            get
            {
                return unitOfWork.Sessao;
            }
        }

        #endregion
        #region Construtores
        public RepositorioMestre(IUnitOfWork unidadeDeTrabalho)
        {
            this.unitOfWork = (NhibernateUtil)unidadeDeTrabalho;
        }
        #endregion

        public void Salvar(T entidade)
        {                        
            Sessao.Save(entidade);
        }

        public void Alterar(T entidade)
        {         
            Sessao.Update(entidade);                        
        }

        public void Excluir(T entidade)
        {            
            Sessao.Delete(entidade);            
        }
        public ICollection<T> BuscarTodos()
        {         
            var dados = Sessao.CreateCriteria(typeof(T)).List();
            return dados.OfType<T>().ToList();         
        }

        public T BuscarPorId(int id)
        {                        
            return Sessao.Get(typeof(T), id) as T;
        }        

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
               
    }
}
