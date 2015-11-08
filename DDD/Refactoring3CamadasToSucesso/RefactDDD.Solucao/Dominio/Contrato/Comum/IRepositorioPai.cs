using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Dominio.Contrato.Comum
{
    /// <summary>
    /// Repositório Pai.
    /// Contrato entre a camada de domínio e a camada de infraestrutura
    /// O que a diferencia da Camada DAO é justamente a sua forma desacoplada
    /// Aqui, não pode existir de forma alguma uma chamada a uma propriedade
    /// como por exemplo FindById(int id), isso deve ser trocado pelo padrão Specification
    /// que deve pertencer apenas ao Repositório especifico da entidade
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorioPai<T>: IUnitOfWork
        where T: class
    {
        void Criar(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        ICollection<T> BuscarTodos();

        ICollection<T> FiltrarCompostoPor(Func<T, bool> predicado);
        T FiltrarSimplesPor(Func<T, bool> predicado);
    }
}
