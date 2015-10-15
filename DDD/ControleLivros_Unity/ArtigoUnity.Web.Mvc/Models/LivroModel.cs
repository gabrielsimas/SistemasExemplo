using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtigoUnity.Web.Mvc.Models
{
    public enum TipoFiltro
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
    
    public class LivroModelCadastro
    {
        public String Isbn { get; set; }
        public String Titulo { get; set; }
        public String Genero { get; set; }
        public String Sinopse { get; set; }
        public String Autor { get; set; }

        public Nullable<long> IdEditora { get; set; }

        public List<SelectListItem> Editoras { get; set; }
    }

    public class LivroModelConsulta
    {
        public Nullable<long> Id { get; set; }
        public String Isbn { get; set; }
        public String Titulo { get; set; }
        public String Genero { get; set; }
        public String Sinopse { get; set; }
        public String Autor { get; set; }

        public String Editora { get; set; }
    }

    public class LivroModelFiltro
    {
        public TipoFiltro Filtro { get; set; }
        public String CampoBusca { get; set; }

    }
}