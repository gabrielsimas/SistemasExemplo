using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Persistencia;

namespace BLL.Tarefas
{
    public class NegocioTarefa: IDisposable
    {
        private TarefaDao dao;

        public void CadastrarTarefa(Tarefa tarefa)
        {
            using (dao = new TarefaDao())
            {
                dao.Criar(tarefa);
            }
        }

        public void AlterarTarefa(Tarefa tarefa)
        {
            using (dao = new TarefaDao())
            {
                Tarefa tarefaBanco = dao.BuscarPorId(tarefa.Id);
                tarefaBanco.DataDeEntrega = tarefa.DataDeEntrega;
                tarefaBanco.Descricao = tarefa.Descricao;
                tarefaBanco.Estado = tarefa.Estado;
                tarefaBanco.Nome = tarefa.Nome;

                dao.Editar(tarefa);
            }
        }

        public Tarefa BuscarTarefaPorId(int idTarefa)
        {
            using(dao = new TarefaDao())
            {
                return dao.BuscarPorId(idTarefa);
            }
        }

        public Boolean ApagarTarefa(int idTarefa)
        {
            try
            {
                using (dao = new TarefaDao())
                {
                    int idParaExclusao = dao.BuscarPorId(idTarefa).Id;
                    dao.Excluir(idParaExclusao);

                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;                
            }
        }

        public Boolean MarcarTarefaComoConcluida(int idTarefa)
        {
            try
            {
                using(dao = new TarefaDao())
                {
                    Tarefa tarefa = dao.BuscarPorId(idTarefa);
                    tarefa.Estado = EstadoTarefa.Executada;
                    dao.Editar(tarefa);

                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ICollection<Tarefa> ListarTarefasNaoConcluidas(int idUsuario)
        {
            using(dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.Estado.Equals(EstadoTarefa.EmAberto) && t.IdUsuario.Equals(idUsuario)).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTarefasAVencer(int idUsuario)
        {
            using (dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.Estado.Equals(EstadoTarefa.EmAberto) && t.IdUsuario.Equals(idUsuario) && t.DataDeEntrega > DateTime.Now).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTarefasConcluidas(int idUsuario)
        {
            using (dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.Estado.Equals(EstadoTarefa.Executada) && t.IdUsuario.Equals(idUsuario)).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTaregasConcluidasNoPrazo(int idUsuario)
        {
            using (dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.Estado.Equals(EstadoTarefa.Executada) && t.IdUsuario.Equals(idUsuario) && DateTime.Now <= t.DataDeEntrega).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTarefasConcluidasForaDoPrazo(int idUsuario)
        {
            using (dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.Estado.Equals(EstadoTarefa.Executada) && t.IdUsuario.Equals(idUsuario) && DateTime.Now > t.DataDeEntrega).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTarefasAtrasadas(int idUsuario)
        {
            using (dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.Estado.Equals(EstadoTarefa.EmAberto) && DateTime.Now > t.DataDeEntrega && t.IdUsuario.Equals(idUsuario)).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, EstadoTarefa estado, int idUsuario)
        {
            using (dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.IdUsuario.Equals(idUsuario) && t.Estado.Equals(estado) && (t.DataDeEntrega >= dataInicio && t.DataDeEntrega <= dataTermino)).ToList<Tarefa>();
            }
        }

        public ICollection<Tarefa> ListarTodasAsTarefasDoUsuario(int idUsuario)
        {
            using(dao = new TarefaDao())
            {
                return dao.BuscarTodos().Where(t => t.IdUsuario.Equals(idUsuario)).ToList<Tarefa>();
            }
        }

        public void Dispose()
        {
            dao.Dispose();
        }
    }
}
