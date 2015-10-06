using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Infraestrutura.DTO.Filtro.Estrategia;

namespace ArtigoUnity.Infraestrutura.DTO.Filtro
{
    public class FiltroLivroDto
    {
        public Nullable<long> Id { get; set; }
        public String Isbn { get; set; }
        public String Titulo { get; set; }
        public String Genero { get; set; }
        public String Sinopse { get; set; }
        public String Autor { get; set; }
        public EstrategiaLivroDto Estrategia { get; set; }

        public SingularOuPlural MostraDados { get; set; }
    }
}
