using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto
{
    public enum Status
    {
        inativo = 0,
        ativo = 1
    }

    public class UsuarioDto
    {
        public Nullable<long> Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Login { get; set; }
        public string senha { get; set; }
        public Status status { get; set; }
        public ICollection<TarefaDto> Tarefas { get; set; }
    }
}
