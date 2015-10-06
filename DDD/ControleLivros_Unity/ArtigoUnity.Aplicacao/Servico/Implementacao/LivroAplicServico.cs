using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Aplicacao.Servico.Fachada;
using ArtigoUnity.Dominio.Servico.Interfaces;
using ArtigoUnity.Infraestrutura.DTO;
using ArtigoUnity.Infraestrutura.DTO.Filtro;

namespace ArtigoUnity.Aplicacao.Servico.Implementacao
{
    public class LivroAplicServico: ILivroAplicServico
    {
        #region Atributos

        private ILivroServico livroServico;

        #endregion

        #region Construtores
        public LivroAplicServico(ILivroServico servico)
        {
            this.livroServico = servico;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
