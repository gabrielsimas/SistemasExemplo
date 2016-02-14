using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using Dominio.Entidade;
using AutoMapper;

namespace Aplicacao.Mappers
{
    public class PerfilEntidadeParaDtoEViceVersa: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Tarefa, TarefaDto>().ReverseMap();

            Mapper.CreateMap<Usuario, UsuarioDto>()
                .ForMember(dto => dto.Tarefas, entd => entd.MapFrom(e => e.Tarefas))
                .ReverseMap();
        }

    }
}
