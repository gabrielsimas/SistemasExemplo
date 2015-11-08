using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;

namespace Aplicacao.Servico.Fachada
{
    public interface ITarefaAplicServico: IDisposable
    {
        void CadastrarTarefa(TarefaDto tarefa);
        void AlterarTarefa(TarefaDto tarefa);
        void ApagarTarefa(TarefaDto tarefa);
        void MarcarTarefaComoConcluida(TarefaDto tarefa);

        TarefaDto BuscarTarefa(TarefaDto tarefa);
        ICollection<TarefaDto> ListarTarefasNaoConcluidas(TarefaDto tarefa);
        ICollection<TarefaDto> ListarTarefasAVencer(TarefaDto tarefa);
        ICollection<TarefaDto> ListarTarefasConcluidas(TarefaDto tarefa);
        ICollection<TarefaDto> ListarTarefasConcluidasForaDoPrazo(TarefaDto tarefa);
        ICollection<TarefaDto> ListarTarefasAtrasadas(TarefaDto tarefa);
        ICollection<TarefaDto> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, TarefaDto tarefa);
        ICollection<TarefaDto> ListarTodasAsTarefasDoUsuario(TarefaDto tarefa);
    }
}
