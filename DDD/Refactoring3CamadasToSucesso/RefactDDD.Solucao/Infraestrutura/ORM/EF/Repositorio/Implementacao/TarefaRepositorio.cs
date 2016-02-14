using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void CadastrarNovaTarefa(Tarefa novaTarefa)
        {
            //Conexao.ChangeTracker.Entries<Usuario>().ToList().ForEach(p => p.State = EntityState.Unchanged); 

            Conexao.Entry(novaTarefa).State = EntityState.Added;
                      
        }
    }
}
