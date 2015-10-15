using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Dominio.Contrato.Repositorio
{
    public interface IRepositorioMestre<T>
        where T: class
    {
        /// <summary>
        /// Grava uma Entidade no Banco
        /// </summary>
        /// <param name="entidade">Entidade a ser persistida</param>
        void Salvar(T entidade);

        /// <summary>
        /// Altera valores de uma entidade
        /// </summary>
        /// <param name="entidade">Entidade a ser persistida</param>
        void Alterar(T entidade);

        /// <summary>
        /// Exclui uma entidade do Banco
        /// </summary>
        /// <param name="entidade">Entidade a ser persistida</param>
        void Excluir(T entidade);

        /// <summary>
        /// Lista todas as entidades presentes no Banco
        /// </summary>
        /// <returns>Entidade a ser persistida</returns>
        ICollection<T> BuscarTodos();

        /// <summary>
        /// Lista uma entidade mediante seu identificador
        /// </summary>
        /// <param name="id">identificador da Entidade</param>
        /// <returns>Entidade</returns>
        T BuscarPorId(int id);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
