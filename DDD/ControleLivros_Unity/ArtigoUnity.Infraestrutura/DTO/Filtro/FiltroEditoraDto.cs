using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Infraestrutura.DTO.Filtro.Estrategia;

namespace ArtigoUnity.Infraestrutura.DTO.Filtro
{
    public class FiltroEditoraDto
    {
        public Nullable<long> Id { get; set; }
        public String Nome { get; set; }

        public EstrategiaEditoraDto Estrategia { get; set; }

        public SingularOuPlural MostraDados { get; set; }

    }
}
