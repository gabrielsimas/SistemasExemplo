using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Dominio.Contrato.Servico;

namespace MVCAngularJS.Dominio.Servico
{
    public class ServicoMestre<T>: IServicoMestre<T>
        where T: class
    {
        #region Atributos

        private IRepositorioMestre<T> repositorio;

        #endregion
        #region Construtores
        public ServicoMestre(IRepositorioMestre<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        #endregion

        #region Métodos de Serviço de Domínio
        public void Cadastrar(T entidade)
        {
            repositorio.Salvar(entidade);
        }

        public void Alterar(T entidade)
        {
            repositorio.Alterar(entidade);
        }

        public void Excluir(T entidade)
        {
            repositorio.Excluir(entidade);
        }

        public T BuscarPorId(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        public ICollection<T> BuscarTodos()
        {
            return repositorio.BuscarTodos();
        }
        public void BeginTransaction()
        {
            repositorio.BeginTransaction();
        }

        public void Commit()
        {
            repositorio.Commit();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        #endregion                   
    }
}
