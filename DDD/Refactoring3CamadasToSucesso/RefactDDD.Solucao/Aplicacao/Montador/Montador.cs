using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using Dominio.Entidade;
using Framework.Utils;

namespace Aplicacao.Montador
{
    public class Montador
    {
        private Montador()
        {

        }

        public static Tarefa Monta(TarefaDto dto)
        {
            if (dto != null)
            {
                Tarefa entidade = new Tarefa()
                {
                    DataDaEntrega = dto.DataDaEntrega,
                    Descricao = dto.Descricao,
                    Estado = (Dominio.Entidade.EstadoTarefa)dto.Estado,
                    Id = dto.Id,
                    IdUsuario = dto.Usuario.Id,
                    Nome = dto.Nome
                };

                return entidade;
            }
            else
            {
                return null;
            }
        }

        public static TarefaDto Monta(Tarefa entidade)
        {
            if (entidade != null)
            {
                TarefaDto dto = new TarefaDto()
                {
                    DataDaEntrega = entidade.DataDaEntrega,
                    Descricao = entidade.Descricao,
                    Estado = (Aplicacao.Dto.EstadoTarefa) entidade.Estado,
                    Id = entidade.Id,
                    Nome = entidade.Nome
                };

                return dto;
            }
            else
            {
                return null;
            }
        }

        public static Usuario Monta(UsuarioDto dto)
        {
            if(dto != null)
            {
                Usuario entidade = new Usuario()
                {
                    Id = dto.Id,
                    Login = dto.Login,
                    NomeCompleto = dto.NomeCompleto,
                    Senha = dto.senha,
                    Status = (Dominio.Entidade.Status)dto.status
                };

                return entidade;
            }
            else
            {
                return null;
            }
        }

        public static UsuarioDto Monta(Usuario entidade)
        {
            if (entidade != null)
            {
                UsuarioDto dto = new UsuarioDto()
                {
                    Id = entidade.Id,
                    Login = entidade.Login,
                    NomeCompleto = entidade.NomeCompleto,
                    senha = entidade.Senha,
                    status = (Aplicacao.Dto.Status)entidade.Status
                };

                return dto;
            }
            else
            {
                return null;
            }
        }

        public static ICollection<Tarefa> Monta(ICollection<TarefaDto> dtos)
        {
            if (dtos != null && dtos.Count > 0)
            {
                ICollection<Tarefa> tarefas = new List<Tarefa>();
                foreach(TarefaDto dto in dtos)
                {
                    Tarefa tarefa = Monta(dto);

                    tarefas.Add(tarefa);
                }

                return tarefas;
            }
            else
            {
                return null;
            }
        }

        public static ICollection<TarefaDto> Monta(ICollection<Tarefa> tarefas)
        {
            if (tarefas != null && tarefas.Count > 0)
            {
                ICollection<TarefaDto> dtos = new List<TarefaDto>();
                foreach(Tarefa tarefa in tarefas)
                {
                    TarefaDto dto = Monta(tarefa);
                    dtos.Add(dto);
                }

                return dtos;
            }
            else
            {
                return null;
            }
        }        
    }
}
