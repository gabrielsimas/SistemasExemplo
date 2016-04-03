using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using Aplicacao.Mappers;
using Aplicacao.Servico.Fachada;
using AutoMapper;
using Dominio.Entidade;
using Dominio.Servico.Interfaces;

namespace Aplicacao.Servico.Implementacao
{
    public class TarefaAplicServico: ITarefaAplicServico
    {
        #region Atributos

        private ITarefaServicoDominio dominio;
        private IMapper mapper;

        #endregion

        #region Construtor
        public TarefaAplicServico(ITarefaServicoDominio dominio)
        {
            this.dominio = dominio;
            this.mapper = AutoMapperConfigFactory.GetMapper();
        }
        #endregion

        #region Implementação da Fachada
        public void CadastrarTarefa(TarefaDto tarefa)
        {
            //Pega o Dto e converte para entidade

            if (tarefa != null)
            {
                //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
                dominio.CadastrarTarefa(mapper.Map<Tarefa>(tarefa));
                dominio.CommitAlteracoes();
            }
            else
            {
                throw new ArgumentNullException("Tarefa vazia. Não podemos cadastrar objetos vazios.");
            }

            
        }

        public void AlterarTarefa(TarefaDto tarefa)
        {
            if (tarefa != null)
            {
                //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
                dominio.AlterarTarefa(mapper.Map<Tarefa>(tarefa));
                dominio.CommitAlteracoes();
            }
            else
            {
                throw new ArgumentNullException("Tarefa vazia. Não podemos alterar objetos vazios.");
            }
            
        }

        public void ApagarTarefa(TarefaDto tarefa)
        {
            if (tarefa != null || !tarefa.Id.HasValue)
            {
                //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
                dominio.ApagarTarefa(mapper.Map<Tarefa>(tarefa));
                dominio.CommitAlteracoes();
            }
            else
            {
                throw new ArgumentNullException("Tarefa vazia. Não podemos excluir objetos vazios.");
            }
            
        }

        public void MarcarTarefaComoConcluida(TarefaDto tarefa)
        {
            if (tarefa != null || !tarefa.Id.HasValue)
            {
                //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
                dominio.MarcarTarefaComoConcluida(mapper.Map<Tarefa>(tarefa));
                dominio.CommitAlteracoes();
            }
            else
            {
                throw new ArgumentNullException("Tarefa vazia. Não podemos marcar tarefas que não existem.");
            }
            
        }

        public TarefaDto BuscarTarefa(TarefaDto tarefa)
        {
            
            Tarefa tarefaDom = new Tarefa();                        

            //tarefaDom = mapper.Map<Tarefa>(tarefa);
            tarefaDom = dominio.BuscarTarefa(mapper.Map<Tarefa>(tarefa));

            if (tarefaDom.Id.HasValue)
            {
                return mapper.Map<TarefaDto>(tarefaDom);                
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasNaoConcluidas(TarefaDto tarefa)
        {
            //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasNaoConcluidas(mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {

                return mapper.Map<ICollection<Tarefa>, ICollection<TarefaDto>>(tarefas);
                
            }
            else
            {
                return null;
            }             
        }

        public ICollection<TarefaDto> ListarTarefasAVencer(TarefaDto tarefa)
        {            
            ICollection<Tarefa> tarefas = dominio.ListarTarefasAVencer(mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {
                return mapper.Map<ICollection<Tarefa>, ICollection<TarefaDto>>(tarefas);
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasConcluidas(TarefaDto tarefa)
        {
            ICollection<Tarefa> tarefas = dominio.ListarTarefasConcluidas(mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {
                //ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);
                return mapper.Map<ICollection<Tarefa>,ICollection<TarefaDto>>(tarefas);
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasConcluidasForaDoPrazo(TarefaDto tarefa)
        {            
            ICollection<Tarefa> tarefas = dominio.ListarTarefasConcluidasForaDoPrazo(mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {
                return mapper.Map<ICollection<Tarefa>, ICollection<TarefaDto>>(tarefas);
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasAtrasadas(TarefaDto tarefa)
        {
            //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasAtrasadas(mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {
                //ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);
                //return dtos;
                return mapper.Map<ICollection<Tarefa>, ICollection<TarefaDto>>(tarefas);
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, TarefaDto tarefa)
        {
            ICollection<Tarefa> tarefas = dominio.ListarTarefasPorData(dataInicio, dataTermino, mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {         
                return mapper.Map<ICollection<Tarefa>, ICollection<TarefaDto>>(tarefas);
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTodasAsTarefasDoUsuario(TarefaDto tarefa)
        {
            //Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTodasAsTarefasDoUsuario(mapper.Map<Tarefa>(tarefa));

            if (tarefas != null && tarefas.Count > 0)
            {
                /*ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);

                return dtos;*/
                return mapper.Map<ICollection<Tarefa>, ICollection<TarefaDto>>(tarefas);
            }
            else
            {
                return null;
            }
        }

        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }        
    }
}
