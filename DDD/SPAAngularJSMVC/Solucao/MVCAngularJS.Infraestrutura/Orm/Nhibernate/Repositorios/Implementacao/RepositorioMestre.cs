using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Infraestrutura.Orm.Nhibernate.Configuracao;
using NHibernate;

namespace MVCAngularJS.Infraestrutura.Orm.Nhibernate.Repositorios.Implementacao
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



        public void BeginTransaction()
        {
            unitOfWork.IniciarTransacao();
        }

        public void Commit()
        {
            unitOfWork.GravaAlteracoesNoBanco();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
