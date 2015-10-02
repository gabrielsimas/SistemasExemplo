using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Repositorio.Interfaces.Base
{
    /// <summary>
    /// Classe Base de InfraEstrutura
    /// É a Camada Responsável por se comunicar com o Banco de Dados
    /// Subsituto à Camada de Dao
    /// </summary>
    /// <typeparam name="T">Entidade a ser persistida</typeparam>
    public interface IRepositorioBase<T>
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
        void Dispose();
    }
}
