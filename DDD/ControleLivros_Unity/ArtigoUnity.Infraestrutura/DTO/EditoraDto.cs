using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Infraestrutura.DTO
{
    public class EditoraDto
    {
        public Nullable<long> Id { get; set; }
        public String Nome { get; set; }
        public ICollection<LivroDto> Livros { get; set; }
    }
}
