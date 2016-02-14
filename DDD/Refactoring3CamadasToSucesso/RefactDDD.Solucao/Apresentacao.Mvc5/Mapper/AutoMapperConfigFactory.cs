using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacao.Dto;
using Apresentacao.Mvc5.Models;
using AutoMapper;
using Dominio.Entidade;

namespace Apresentacao.Mvc5.Mapper
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
                    cfg.CreateMap<AutenticacaoModel, UsuarioDto>().ReverseMap();

                    cfg.CreateMap<TarefaCadastroModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore())
                        .ReverseMap(); //Ignora o Mapeamento de Usuario - filho de tarefa nesse caso - pq precisamos instanciar Usuario

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

                    cfg.CreateMap<UsuarioCadastroModel, UsuarioDto>().ReverseMap();                        
                    
                    /*
                    cfg.CreateMap<TarefaDto, TarefaCadastroModel>()
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
                    */

                    cfg.CreateMap<TarefaEdicaoModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore()) //Ignora o Mapeamento de Usuario - filho de tarefa nesse caso - pq precisamos instanciar Usuario
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

                    cfg.CreateMap<TarefaDto, TarefaEdicaoModel>()
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

                    cfg.CreateMap<TarefaExcluirModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore()) //Ignora o Mapeamento de Usuario - filho de tarefa nesse caso - pq precisamos instanciar Usuario
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

                    cfg.CreateMap<TarefaDto, TarefaListarModel>()
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

                    cfg.CreateMap<TarefaListarModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario, opt => opt.Ignore()) //Ignora o Mapeamento de Usuario - filho de tarefa nesse caso - pq precisamos instanciar Usuario
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