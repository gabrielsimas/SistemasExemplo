using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contrato;
using Dominio.Entidade;
using Infraestrutura.ORM.EF.ContextoDB;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Infraestrutura.ORM.EF.Repositorio.Implementacao
{
    public class TarefaRepositorio: RepositorioPai<Tarefa,Conexao>, ITarefaRepositorio
    {
        public TarefaRepositorio(Conexao conexao)
            :base(conexao)
        {

        }
    }
}
