using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Dominio.Servico.Interfaces;
using ArtigoUnity.Infraestrutura.IoC.MicrosoftUnity;

namespace ArtigoUnity.Dominio.Servico.Implementacao
{
    public class LivroServico: ILivroServico, IDisposable
    {
        #region Atributos

        private ILivroRepositorio livroRepositorio;
        private IEditoraRepositorio editoraRepositorio;

        #endregion
 
        #region Construtores
        public LivroServico(ILivroRepositorio livroRepositorio, IEditoraRepositorio editoraRepositorio)
        {
            this.livroRepositorio = livroRepositorio;
            this.editoraRepositorio = editoraRepositorio;
        }

        #endregion

        #region Propriedades

        public ILivroRepositorio LivroRepositorio
        {
            get { return this.livroRepositorio; }
            set { this.livroRepositorio = value; }
        }

        public IEditoraRepositorio EditoraRepositorio
        {
            get { return this.editoraRepositorio; }
            set { this.editoraRepositorio = value; }
        }

        #endregion        

        #region Método de Servico

        public void Cadastrar(Livro entidade)
        {
            this.livroRepositorio.Salvar(entidade);
            this.livroRepositorio.CommitAlteracoes();
        }

        public Livro BuscarPorId(long? id)
        {
            return this.livroRepositorio.BuscarPorId(id);
        }

        public ICollection<Livro> ListarTudo()
        {
            return this.livroRepositorio.BuscarTodos();
        }
        
        public Livro BuscarLivroPorIsbn(string isbn)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Isbn.Equals(isbn)).Single();
        }

        public ICollection<Livro> BuscarLivrosPorTrechoDoTitulo(string trecho)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Titulo.StartsWith(trecho)).ToList();
        }

        public ICollection<Livro> BuscarLivrosPorGenero(string genero)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Genero.Equals(genero)).ToList();
        }

        public ICollection<Livro> BuscarLivrosPorAutor(string nomeAutor)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Autor.Equals(nomeAutor)).ToList();
        }

        public ICollection<Livro> BuscarLivrosPorEditora(string nomeEditora)
        {
            return this.livroRepositorio.BuscarTodos().Where(l => l.Editora.Nome.Equals(nomeEditora)).ToList();
        }

        public void Alterar(Livro entidade)
        {
            Livro livro = this.livroRepositorio.BuscarPorId(entidade.Id);
            livro.Autor = entidade.Autor;
            livro.Editora = entidade.Editora;
            livro.Genero = entidade.Genero;
            livro.Isbn = entidade.Isbn;
            livro.Sinopse = entidade.Sinopse;
            livro.Titulo = entidade.Titulo;

            this.livroRepositorio.Alterar(livro);
            this.livroRepositorio.CommitAlteracoes();
        }

        public void Excluir(Livro entidade)
        {
            this.livroRepositorio.Excluir(entidade);
            this.livroRepositorio.CommitAlteracoes();
        }        

        public void Dispose()
        {
            this.livroRepositorio.Dispose();
        }

        #endregion   
    }
}
