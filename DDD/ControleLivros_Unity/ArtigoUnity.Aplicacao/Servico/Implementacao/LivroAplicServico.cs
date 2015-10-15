using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Aplicacao.Servico.Fachada;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Servico.Interfaces;
using ArtigoUnity.Infraestrutura.DTO;
using ArtigoUnity.Infraestrutura.DTO.Filtro;

namespace ArtigoUnity.Aplicacao.Servico.Implementacao
{
    public class LivroAplicServico: ILivroAplicServico
    {
        #region Atributos

        private ILivroServico livroServico;
        private IEditoraServico editoraServico;

        #endregion

        #region Construtores
        public LivroAplicServico(ILivroServico servico, IEditoraServico editoraServico)
        {            
            this.livroServico = servico;
            this.editoraServico = editoraServico;
        }

        #endregion

        #region Propriedades
        public ILivroServico LivroServico
        {
            get
            {
                return this.livroServico;
            }

            set
            {
                this.livroServico = value;
            }
        }
        #endregion

        #region Métodos de Aplicação
        public void CadastrarLivro(LivroDto Dto, long? idEditoraDto)
        {
            if (Dto == null && (idEditoraDto == null || idEditoraDto == 0))
            {
                throw new Exception("Não é permitido valor nulo!");
            }
            else
            {
                Livro livro = new Livro();
                Montador.Montador.Assemblador(Dto, livro);

                if (idEditoraDto > 0)
                {
                    Editora editora = editoraServico.BuscarPorId(idEditoraDto);
                    EditoraDto editoraDto = new EditoraDto();

                    Montador.Montador.Assemblador(editora,editoraDto);
                    Dto.Editora = new EditoraDto();
                    Dto.Editora = editoraDto;
                }

                livroServico.Cadastrar(livro);
            }
        }

        public void EditarLivro(LivroDto dto)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLivro(LivroDto dto)
        {
            throw new NotImplementedException();
        }

        public LivroDto BuscarLivroPorId(long? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<LivroDto> ListarTodosOsLivros()
        {
            ICollection<Livro> livros = livroServico.ListarTudo();

            if (livros != null && livros.Count > 0)
            {
                ICollection<LivroDto> dtos = new List<LivroDto>();
                foreach(Livro livro in livros)
                {
                    LivroDto dto = new LivroDto();
                    Montador.Montador.Assemblador(livro, dto);

                    dtos.Add(dto);
                }

                return dtos;
            }

            return null;
        }
        public ICollection<LivroDto> ListarTodosOsLivrosPaginado(int totalPaginas, int paginaAtual)
        {
            throw new NotImplementedException();
        }

        public ICollection<LivroDto> FiltrarLivroPor(FiltroLivroDto filtro)
        {
            throw new NotImplementedException();
        }
        #endregion                
    }
}
