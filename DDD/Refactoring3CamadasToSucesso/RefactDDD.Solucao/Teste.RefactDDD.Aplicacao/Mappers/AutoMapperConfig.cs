using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;
using Apresentacao.Mvc5.Models;
using AutoMapper;
using Dominio.Entidade;

namespace Teste.RefactDDD.Aplicacao.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterProfiles()
        {
            var config = new MapperConfiguration(
                cfg =>
                {

                    cfg.CreateMap<Tarefa, TarefaDto>()                                                
                        .ReverseMap();

                    cfg.CreateMap<TarefaCadastroModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore());

                    cfg.CreateMap<TarefaExcluirModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore())
                        .AfterMap((model, dto) =>
                        {
                            if (model.IdUsuario.HasValue)
                            {
                                dto.Usuario = new UsuarioDto()
                                {
                                    Id = model.IdUsuario
                                };
                            }
                        }
                        );

                    cfg.CreateMap<Usuario, UsuarioDto>()
                        .ForMember(dto => dto.Tarefas, entd => entd.MapFrom(e => e.Tarefas))
                        .ReverseMap();
                           
                    cfg.CreateMap<Usuario, UsuarioDto>()                        
                        .ReverseMap();

                    cfg.CreateMap<TarefaCadastroModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore());

                    cfg.CreateMap<TarefaDto, TarefaCadastroModel>()
                        .ReverseMap();

                    cfg.CreateMap<TarefaEdicaoModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore()); //Ignora o Mapeamento de Usuario - filho de tarefa nesse caso - pq precisamos instancia/Usuario
                        /*
                        .AfterMap((model, dto) =>
                        {
                            if (model.IdUsuario.HasValue)
                            {
                                dto.Usuario = new UsuarioDto()
                                {
                                    Id = model.IdUsuario
                                };
                            }
                        }
                        );
                         */

                    cfg.CreateMap<TarefaDto, TarefaEdicaoModel>()
                        .ReverseMap();
                        

                    cfg.CreateMap<TarefaExcluirModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore())
                        .AfterMap((model, dto) =>
                        {
                            if (model.IdUsuario.HasValue)
                            {
                                dto.Usuario = new UsuarioDto()
                                {
                                    Id = model.IdUsuario
                                };
                            }
                        }
                        );

                    cfg.CreateMap<TarefaDto, TarefaExcluirModel>()
                        .AfterMap(
                            (dto, model) =>
                            {
                                if (dto.Usuario != null)
                                {
                                    if (dto.Usuario.Id.HasValue)
                                    {
                                        model.IdUsuario = dto.Usuario.Id.Value;
                                    }
                                }
                            }
                        );

                    cfg.CreateMap<AutenticacaoModel, UsuarioDto>().ReverseMap();
                }
                                
            );

            var mapper = config.CreateMapper();

            return mapper;

        }
    }
}
