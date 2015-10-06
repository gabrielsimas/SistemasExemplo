using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;

namespace ArtigoUnity.Dominio.Repositorio.Interfaces.Base
{
    /// <summary>
    /// Contrato do Domínio com o Repositório    
    /// </summary>
    /// <typeparam name="T">Entidade do Domínio a ser persistida</typeparam>
    public interface IRepositorioBase<T>
        where T : EntidadeBase
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
        T BuscarPorId(Nullable<long> id);

        /// <summary>
        /// Lista uma entidade de acordo com expressão Lambda inserida como parâmetro
        /// </summary>
        /// <param name="predicado">Expressão Lambda de Filtro</param>
        /// <returns></returns>
        T FiltrarUmPor(Func<T, Boolean> predicado);

        /// <summary>
        /// Lista todas as entidades mediante uma expressão Lambda inserida como parâmetro
        /// </summary>
        /// <param name="predicado">Expressão Lambda de Filtro</param>
        /// <returns></returns>
        ICollection<T> FiltrarVariosPor(Func<T, Boolean> predicado);

        ICollection<T> BuscarTodos(int pageIndex, int pageCount);
        ICollection<T> FiltrarVariosPor(Func<T, Boolean> predicado,int pageIndex, int pageCount);
        void Dispose();
    }
}
