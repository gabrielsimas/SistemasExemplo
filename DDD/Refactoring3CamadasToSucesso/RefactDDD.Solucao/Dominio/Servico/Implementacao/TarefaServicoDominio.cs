using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contrato;
using Dominio.Entidade;
using Dominio.Servico.Comum;
using Dominio.Servico.Interfaces;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Dominio.Servico.Implementacao
{
    public class TarefaServicoDominio: ITarefaServicoDominio
    {
        #region Atributos
        
        private ITarefaRepositorio repositorio;

        #endregion

        #region Construtores

        public TarefaServicoDominio(ITarefaRepositorio repositorio)
        {            
            this.repositorio = repositorio;
        }

        #endregion

        #region Métodos do Serviço de Domínio

        public void CadastrarTarefa(Tarefa tarefa)
        {
            repositorio.Criar(tarefa);
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            Tarefa tarefaBd = repositorio.FiltrarSimplesPor(t => t.Id.Equals(tarefa.Id) && t.Usuario.Id.Equals(tarefa.Usuario.Id));

            if(tarefaBd.Id.HasValue)
            {
                tarefaBd.DataDaEntrega = tarefa.DataDaEntrega;
                tarefaBd.Descricao = tarefa.Descricao;
                tarefaBd.Estado = tarefa.Estado;
                tarefaBd.Nome = tarefa.Nome;

                repositorio.Editar(tarefaBd);
            }
        }

        public void ApagarTarefa(Tarefa tarefa)
        {
            repositorio.Excluir(tarefa);
        }

        public void MarcarTarefaComoConcluida(Tarefa tarefa)
        {
            Tarefa tarefaBd = repositorio.FiltrarSimplesPor(t => t.Id.Equals(tarefa.Id));
            tarefaBd.Estado = EstadoTarefa.Executada;
            repositorio.Editar(tarefaBd);
        }

        public Tarefa BuscarTarefa(Tarefa tarefa)
        {
            return repositorio.FiltrarSimplesPor(t => t.Id.Equals(tarefa.Id));
        }

        public ICollection<Tarefa> ListarTarefasNaoConcluidas(Tarefa tarefa)
        {
            Nullable<long> idUsuario = tarefa.Usuario.Id;
            return repositorio.FiltrarCompostoPor(t=>t.Estado.Equals(EstadoTarefa.EmAberto) && t.Usuario.Id.Equals(idUsuario));
        }

        public ICollection<Tarefa> ListarTarefasAVencer(Tarefa tarefa)
        {
            Nullable<long> idUsuario = tarefa.Usuario.Id;            
            return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.EmAberto) && t.Usuario.Id.Equals(idUsuario) && t.DataDaEntrega > DateTime.Now);
        }

        public ICollection<Tarefa> ListarTarefasConcluidas(Tarefa tarefa)
        {            
            Nullable<long> idUsuario = tarefa.Usuario.Id;
            return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.Executada) && t.Usuario.Id.Equals(idUsuario));
        }

        public ICollection<Tarefa> ListarTarefasConcluidasForaDoPrazo(Tarefa tarefa)
        {
            Nullable<long> idUsuario = tarefa.Usuario.Id;
            return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.Executada) && t.Usuario.Id.Equals(idUsuario) && DateTime.Now > t.DataDaEntrega);
        }

        public ICollection<Tarefa> ListarTarefasAtrasadas(Tarefa tarefa)
        {
            Nullable<long> idUsuario = tarefa.Usuario.Id;
            return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.EmAberto) && DateTime.Now > t.DataDaEntrega && t.Usuario.Id.Equals(idUsuario));
        }

        public ICollection<Tarefa> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, Tarefa tarefa)
        {            
            Nullable<long> idUsuario = tarefa.Usuario.Id;
            return repositorio.FiltrarCompostoPor(t => t.Usuario.Id.Equals(idUsuario) && (t.DataDaEntrega >= dataInicio && t.DataDaEntrega <= dataTermino));
        }

        public ICollection<Tarefa> ListarTodasAsTarefasDoUsuario(Tarefa tarefa)
        {            
            Nullable<long> idUsuario = tarefa.Usuario.Id;
            return repositorio.FiltrarCompostoPor(t => t.Usuario.Id.Equals(idUsuario));
        }

        public void CommitAlteracoes()
        {
            repositorio.CommitAlteracoes();
        }

        public void CommitaERefresha()
        {
            repositorio.CommitaERefresha();
        }

        public void DesfazAlteracoes()
        {
            repositorio.DesfazAlteracoes();
        }

        public void Dispose()
        {
            
        }

        #endregion                    
    }
}
