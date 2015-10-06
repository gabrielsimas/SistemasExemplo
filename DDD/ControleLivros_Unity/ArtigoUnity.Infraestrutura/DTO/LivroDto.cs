using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Infraestrutura.DTO
{
    public class LivroDto
    {
        public Nullable<long> Id { get; set; }
        public String Isbn { get; set; }
        public String Titulo { get; set; }
        public String Genero { get; set; }
        public String Sinopse { get; set;}
        public String Autor { get; set; }
        public EditoraDto Editora { get; set; }       
    }
}
