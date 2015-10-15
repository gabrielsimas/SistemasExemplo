using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Infraestrutura.DTO;
using ArtigoUnity.Infraestrutura.DTO.Filtro;

namespace ArtigoUnity.Aplicacao.Servico.Fachada
{
    public interface IEditoraAplicServico
    {
        void CadastrarEditora(EditoraDto dto);
        EditoraDto ListaEditoraPorId(Nullable<long> id);
        IEnumerable<EditoraDto> ListarTodasAsEditoras(int totalPaginas, int paginaAtual);
        Object ListarEditora(FiltroEditoraDto filtro);
        void AlterarDadosEditora(EditoraDto dto);
        void ExcluirEditora(EditoraDto dto);
    }
}
