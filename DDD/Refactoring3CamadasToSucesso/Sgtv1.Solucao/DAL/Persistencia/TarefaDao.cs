using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Persistencia.DataSource;

namespace DAL.Persistencia
{
    public class TarefaDao: IDisposable
    {
        #region Propriedades

        private ConexaoDeDados conexao;

        #endregion

        
        #region Construtores
        public TarefaDao()
        {
            
        }
        #endregion

        #region Métodos de Persistência

        public void Criar(Tarefa tarefa)
        {
            try
            {
                using(ConexaoDeDados conexao = new ConexaoDeDados()){
                    conexao.TbTarefa.Add(tarefa);
                    conexao.SaveChanges();

                }                
            }catch
            {                
                throw;
            }
        }

        public void Editar(Tarefa tarefa)
        {
            try
            {
                using (ConexaoDeDados conexao = new ConexaoDeDados())
                {
                    conexao.Entry(tarefa).State = EntityState.Modified;
                    conexao.SaveChanges();
                }                
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                using (ConexaoDeDados conexao = new ConexaoDeDados())
                {
                    Tarefa tarefa = new Tarefa();
                    tarefa.Id = id;
                    conexao.TbTarefa.Remove(tarefa);
                    conexao.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public Tarefa BuscarPorId(int id)
        {
            try
            {
                using (ConexaoDeDados conexao = new ConexaoDeDados())
                {
                    var tarefaPorId = (from t in conexao.TbTarefa.AsNoTracking()
                                         where t.Id == id
                                         select t).FirstOrDefault<Tarefa>();
                    if (tarefaPorId != null && tarefaPorId.Id > 0)
                    {
                        return tarefaPorId;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public ICollection<Tarefa> BuscarTodos()
        {
            try
            {
                using(conexao = new ConexaoDeDados()){
                    var tarefas = conexao.TbTarefa.AsNoTracking().ToList();

                if (tarefas != null && tarefas.Count > 0)
                {
                    return tarefas;
                }
                else
                {
                    return null;
                }
                }
                
            }
            catch
            {
                throw;
            }
        }

        #endregion

        public void Dispose()
        {
            if (conexao != null)
            {
                conexao.Dispose();
            }            
        }
    }
}
