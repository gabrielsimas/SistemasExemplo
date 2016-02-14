using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dto
{
    public enum EstadoTarefa
    {
        EmAberto = 0,
        Executada = 1
    }

  public class TarefaDto
  {
      public Nullable<long> Id { get; set; }
      public string Nome { get; set; }
      public Nullable<DateTime> DataDaEntrega { get; set; }
      public string Descricao { get; set; }
      public EstadoTarefa Estado { get; set; }
      public Nullable<long> IdUsuario { get; set; }
      public UsuarioDto Usuario {get; set;}      
  }
}
