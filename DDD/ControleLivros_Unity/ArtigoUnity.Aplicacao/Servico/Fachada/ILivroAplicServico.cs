using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Infraestrutura.DTO;
using ArtigoUnity.Infraestrutura.DTO.Filtro;

namespace ArtigoUnity.Aplicacao.Servico.Fachada
{
    public interface ILivroAplicServico
    {

        void CadastrarLivro(LivroDto Dto, Nullable<long> idEditoraDto);
        void EditarLivro(LivroDto dto);
        void ExcluirLivro(LivroDto dto);
        LivroDto BuscarLivroPorId(Nullable<long> id);
        ICollection<LivroDto> ListarTodosOsLivros();
        ICollection<LivroDto> ListarTodosOsLivrosPaginado(int totalPaginas, int paginaAtual);
        ICollection<LivroDto> FiltrarLivroPor(FiltroLivroDto filtro);

    }
}
