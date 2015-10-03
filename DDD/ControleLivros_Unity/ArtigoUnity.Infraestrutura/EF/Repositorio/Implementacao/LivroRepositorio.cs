using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces;

namespace ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao
{
    public class LivroRepositorio: UnityOfWork,  ILivroRepositorio
    {
        #region Atributos

        #endregion

        #region Construtores

        #endregion

        #region Métodos do Repositório

        #endregion
        public void Alterar(Livro entidade)
        {
            
        }

        public Livro BuscarPorId(long? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Livro> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(Livro entidade)
        {
            throw new NotImplementedException();
        }

        public Livro FiltrarUmPor(Func<Livro, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public ICollection<Livro> FiltrarVariosPor(Func<Livro, bool> predicado)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Livro entidade)
        {
            throw new NotImplementedException();
        }
    }
}
