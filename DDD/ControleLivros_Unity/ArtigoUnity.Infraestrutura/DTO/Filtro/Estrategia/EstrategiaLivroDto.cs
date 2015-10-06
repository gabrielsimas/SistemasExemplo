using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Infraestrutura.DTO.Filtro.Estrategia
{
    public enum EstrategiaLivroDto
    {
        PorTitulo = 0,
        PorGenero = 1,
        PorAutor = 2,
        PorEditora = 3,
        PorTituloLike = 4,
        PorGeneroLike = 5,
        PorAutorLike = 6,
        PorEditoraLike = 7               
    }
}
