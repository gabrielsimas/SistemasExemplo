using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using AutoMapper;
using Dominio.Entidade;

namespace Aplicacao.Mappers
{
    public class AutoMapperConfigFactory
    {
        private AutoMapperConfigFactory()
        {

        }

        private static IMapper RegisterProfiles()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Tarefa, TarefaDto>()                        
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore())
                        .ReverseMap();
                        

                    //cfg.CreateMap<TarefaDto, Tarefa>()
                    //    .ForMember(entd => entd.Usuario, dto => dto.MapFrom(d => d.Usuario));                        

                    cfg.CreateMap<Usuario, UsuarioDto>()
                        .ForMember(dto => dto.Tarefas, entd => entd.MapFrom(e => e.Tarefas))
                        .ReverseMap();
                }
            );

            var mapper = config.CreateMapper();

            return mapper;

        }

        public static IMapper GetMapper()
        {
            return RegisterProfiles();
        }
    }
}
