using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;
using Dominio.Servico.Comum;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Dominio.Servico.Interfaces
{
    public interface ITarefaServicoDominio: IUnitOfWork,IDisposable
    {
        #region Persistência
        void CadastrarTarefa(Tarefa tarefa);
        void AlterarTarefa(Tarefa tarefa);
        void ApagarTarefa(Tarefa tarefa);        
        
        void MarcarTarefaComoConcluida(Tarefa tarefa);

        #endregion

        #region Consultas        
        Tarefa BuscarTarefa(Tarefa tarefa);
        ICollection<Tarefa> ListarTarefasNaoConcluidas(Tarefa tarefa);
        ICollection<Tarefa> ListarTarefasAVencer(Tarefa tarefa);
        ICollection<Tarefa> ListarTarefasConcluidas(Tarefa tarefa);
        ICollection<Tarefa> ListarTarefasConcluidasForaDoPrazo(Tarefa tarefa);
        ICollection<Tarefa> ListarTarefasAtrasadas(Tarefa tarefa);
        ICollection<Tarefa> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, Tarefa tarefa);
        ICollection<Tarefa> ListarTodasAsTarefasDoUsuario(Tarefa tarefa);

        #endregion

    }
}
