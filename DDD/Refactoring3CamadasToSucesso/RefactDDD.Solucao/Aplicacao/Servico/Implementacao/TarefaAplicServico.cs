﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Dominio.Entidade;
using Dominio.Servico.Interfaces;

namespace Aplicacao.Servico.Implementacao
{
    public class TarefaAplicServico: ITarefaAplicServico
    {
        #region Atributos

        private ITarefaServicoDominio dominio;

        #endregion

        #region Construtor
        public TarefaAplicServico(ITarefaServicoDominio dominio)
        {
            this.dominio = dominio;
        }
        #endregion

        #region Implementação da Fachada
        public void CadastrarTarefa(TarefaDto tarefa)
        {
            //Pega o Dto e converte para entidade
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
            dominio.CadastrarTarefa(tarefaDom);
            dominio.CommitAlteracoes();
        }

        public void AlterarTarefa(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
            dominio.AlterarTarefa(tarefaDom);
            dominio.CommitAlteracoes();
        }

        public void ApagarTarefa(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
            dominio.ApagarTarefa(tarefaDom);
            dominio.CommitAlteracoes();
        }

        public void MarcarTarefaComoConcluida(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
            dominio.MarcarTarefaComoConcluida(tarefaDom);
            dominio.CommitAlteracoes();
        }

        public TarefaDto BuscarTarefa(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);
            tarefaDom = dominio.BuscarTarefa(tarefaDom);
            if (tarefaDom.Id.HasValue)
            {
                TarefaDto dto = Montador.Montador.Monta(tarefaDom);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasNaoConcluidas(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasNaoConcluidas(tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);
                return dtos;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasAVencer(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasAVencer(tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);
                return dtos;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasConcluidas(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasConcluidas(tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);
                return dtos;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasConcluidasForaDoPrazo(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasConcluidasForaDoPrazo(tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);
                return dtos;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasAtrasadas(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasAtrasadas(tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);

                return dtos;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTarefasPorData(DateTime dataInicio, DateTime dataTermino, TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTarefasPorData(dataInicio,dataTermino,tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);

                return dtos;
            }
            else
            {
                return null;
            }
        }

        public ICollection<TarefaDto> ListarTodasAsTarefasDoUsuario(TarefaDto tarefa)
        {
            Tarefa tarefaDom = Montador.Montador.Monta(tarefa);

            ICollection<Tarefa> tarefas = dominio.ListarTodasAsTarefasDoUsuario(tarefaDom);

            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = Montador.Montador.Monta(tarefas);

                return dtos;
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
