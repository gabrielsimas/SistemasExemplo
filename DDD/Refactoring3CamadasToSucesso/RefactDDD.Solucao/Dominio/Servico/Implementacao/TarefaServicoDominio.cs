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

        /*
        public void CadastrarTarefa(Tarefa tarefa)
        {
            repositorio.Criar(tarefa);
        }
         */

        public void CadastrarTarefa(Tarefa tarefa)
        {
            repositorio.CadastrarNovaTarefa(tarefa);
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            Tarefa tarefaBd = repositorio.FiltrarSimplesPor(t => t.Id.Equals(tarefa.Id) && t.Usuario.Id.Equals(tarefa.IdUsuario));

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
            if (tarefa.IdUsuario.HasValue)
            {
                Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.EmAberto) && t.IdUsuario.Equals(idUsuario));
            }
            else
            {
                return null;
            }         
        }

        public ICollection<Tarefa> ListarTarefasAVencer(Tarefa tarefa)
        {            
            if (tarefa.IdUsuario.HasValue)
            {
                Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.EmAberto) && t.IdUsuario.Equals(idUsuario) && t.DataDaEntrega > DateTime.Now);
            }
            else
            {
                return null;
            }            
        }

        public ICollection<Tarefa> ListarTarefasConcluidas(Tarefa tarefa)
        {
            if (tarefa.Usuario != null)
            {
                if (tarefa.IdUsuario.HasValue)
                {
                    Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                    return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.Executada) && t.IdUsuario.Equals(idUsuario));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }                        
                        
        }

        public ICollection<Tarefa> ListarTarefasConcluidasForaDoPrazo(Tarefa tarefa)
        {
            if (tarefa.Usuario != null)
            {
                if (tarefa.IdUsuario.HasValue)
                {
                    Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                    return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.Executada) && t.IdUsuario.Equals(idUsuario) && DateTime.Now > t.DataDaEntrega);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }                                    
            
        }

        public ICollection<Tarefa> ListarTarefasAtrasadas(Tarefa tarefa)
        {            
            if (tarefa.IdUsuario.HasValue)
            {
                Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                return repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.EmAberto) && DateTime.Now > t.DataDaEntrega && t.IdUsuario.Equals(idUsuario));
            }
            else
            {
                return null;
            }            
        }

        public ICollection<Tarefa> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, Tarefa tarefa)
        {            
            if (tarefa.IdUsuario.HasValue)
            {
                Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                return repositorio.FiltrarCompostoPor(t => t.IdUsuario.Equals(idUsuario) && (t.DataDaEntrega >= dataInicio && t.DataDaEntrega <= dataTermino));
            }
            else
            {
                return null;
            }         
        }

        public ICollection<Tarefa> ListarTodasAsTarefasDoUsuario(Tarefa tarefa)
        {                        
            if (tarefa.IdUsuario.HasValue)
            {
                Nullable<long> idUsuario = tarefa.IdUsuario.Value;

                return repositorio.FiltrarCompostoPor(t => t.IdUsuario.Equals(idUsuario));
            }
            else
            {
                return null;
            }                        
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
