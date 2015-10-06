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
using ArtigoUnity.Aplicacao.Servico.Implementacao.Montador;
using ArtigoUnity.Infraestrutura.DTO.Filtro.Estrategia;

namespace ArtigoUnity.Aplicacao.Servico.Implementacao
{
    public class EditoraAplicServico: IEditoraAplicServico, IDisposable
    {
        #region Atributos

        private IEditoraServico editoraServico;

        #endregion

        #region Construtor
        public EditoraAplicServico(IEditoraServico domainService)
        {
            this.editoraServico = domainService;
        }

        #endregion

        #region Propriedades
        public IEditoraServico EditoraServico
        {
            get { return this.editoraServico; }
            set { this.editoraServico = value; }
        }
        #endregion

        #region Métodos 

        #endregion
        public void CadastrarEditora(EditoraDto dto)
        {
            Editora editora = new Editora();

            Montador.Montador.Assemblador(dto, editora);

            editoraServico.Cadastrar(editora);

        }

        public EditoraDto ListaEditoraPorId(long? id)
        {
            Editora editora = new Editora();
            EditoraDto dto = new EditoraDto();

            editora = editoraServico.BuscarPorId(id);

            Montador.Montador.Assemblador(editora, dto);

            return dto;

        }

        public IEnumerable<EditoraDto> ListarTodasAsEditoras(int totalPaginas, int paginaAtual)
        {
            ICollection<Editora> editoras = new List<Editora>();
            ICollection<EditoraDto> dtos = new List<EditoraDto>();

            editoras = editoraServico.ListarTudo();

            if (editoras != null && editoras.Count > 0)
            {
                foreach (Editora editora in editoras)
                {
                    EditoraDto dto = new EditoraDto();

                    Montador.Montador.Assemblador(editora, dto);

                    dtos.Add(dto);
                }
            }

            return dtos.ToList().Skip(totalPaginas * paginaAtual).Take(totalPaginas);
        }

        public Object ListarEditora(FiltroEditoraDto filtro)
        {           
           ICollection<EditoraDto> dtos = new List<EditoraDto>();
           EditoraDto dto = new EditoraDto();

            if (filtro != null){

                switch (filtro.Estrategia)
                {
                    case EstrategiaEditoraDto.PorId:
                        dto = this.ListaEditoraPorId(filtro.Id);                        
                        break;

                    case EstrategiaEditoraDto.PorNome:
                       dto =  FiltraEditoraPorNome(filtro.Nome);
                       break;

                    case EstrategiaEditoraDto.PorNomeLike:
                       dtos = FiltraEditoraPorNomeLoke(filtro.Nome);
                       break;

                }

            }

            if (dto.Id.HasValue)
            {
                return dto;
            }
            else if (dtos != null && dtos.Count > 0)
            {
                return dtos;
            }

            return null;
        }

        public void AlterarDadosEditora(EditoraDto dto)
        {
            Editora editora = new Editora();

            editora = editoraServico.BuscarPorId(dto.Id);

            if (editora.Id.HasValue)
            {
                Montador.Montador.Assemblador(dto, editora);
                editoraServico.Alterar(editora);            
            }
        }

        public void ExcluirEditora(EditoraDto dto)
        {
            Editora editora = new Editora();

            Montador.Montador.Assemblador(editora, dto);

            editoraServico.Excluir(editora);            
        }

        public void Dispose()
        {
            this.editoraServico.Dispose();
        }

        private EditoraDto FiltraEditoraPorNome(String nome)
        {
            throw new NotImplementedException();
        }

        private ICollection<EditoraDto> FiltraEditoraPorNomeLoke(String Nome){
            throw new NotImplementedException();
        }
    }
}
