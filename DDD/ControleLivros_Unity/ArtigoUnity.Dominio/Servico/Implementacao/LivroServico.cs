using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Dominio.Servico.Interfaces;

namespace ArtigoUnity.Dominio.Servico.Implementacao
{
    public class LivroServico: ILivroServico
    {
        #region Atributos

        private ILivroRepositorio livroRepositorio;

        #endregion
 
        #region Construtores
        public LivroServico(ILivroRepositorio repositorio)
        {
            this.livroRepositorio = repositorio;
        }

        #endregion
        public Livro BuscarLivroPorIsbn(string isbn)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Isbn.Equals(isbn)).Single();
        }

        public ICollection<Livro> BuscarLivrosPorTrechoDoTitulo(string trecho)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Titulo.StartsWith(trecho)).ToList();
        }

        public ICollection<Entidade.Livro> BuscarLivrosPorGenero(string genero)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Genero.Equals(genero)).ToList();
        }

        public ICollection<Entidade.Livro> BuscarLivrosPorAutor(string nomeAutor)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Autor.Equals(nomeAutor)).ToList();
        }

        public ICollection<Entidade.Livro> BuscarLivrosPorEditora(string nomeEditora)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Editora.Nome.Equals(nomeEditora)).ToList();
        }

        public void Cadastrar(Entidade.Livro entidade)
        {
            this.livroRepositorio.Salvar(entidade);
        }

        public void Alterar(Entidade.Livro entidade)
        {
            Livro livro = this.livroRepositorio.BuscarPorId(entidade.Id);
            livro.Autor = entidade.Autor;
            livro.Editora = entidade.Editora;
            livro.Genero = entidade.Genero;
            livro.Isbn = entidade.Isbn;
            livro.Sinopse = entidade.Sinopse;
            livro.Titulo = entidade.Titulo;

            this.livroRepositorio.Alterar(livro);
        }

        public void Excluir(Entidade.Livro entidade)
        {
            this.livroRepositorio.Excluir(entidade);
        }

        public Entidade.Livro BuscarPorId(long? id)
        {
            return this.livroRepositorio.BuscarPorId(id);
        }

        public ICollection<Entidade.Livro> ListarTudo()
        {
            return this.livroRepositorio.BuscarTodos();
        }
    }
}
