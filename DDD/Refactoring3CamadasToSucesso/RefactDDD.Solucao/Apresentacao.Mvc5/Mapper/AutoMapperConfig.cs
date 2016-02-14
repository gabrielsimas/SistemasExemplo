using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

using Apresentacao.Mvc5.Models;
using Aplicacao.Dto;

namespace Apresentacao.Mvc5.Mapper
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterProfiles()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    //Model para Dto
                    cfg.CreateMap<TarefaCadastroModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario.Id,model => model.MapFrom(m => m.IdUsuario));

                    cfg.CreateMap<TarefaEdicaoModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario.Id, model => model.MapFrom(m => m.IdUsuario));

                    cfg.CreateMap<TarefaExcluirModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario.Id, model => model.MapFrom(m => m.IdUsuario));

                    cfg.CreateMap<TarefaEdicaoModel, TarefaDto>()
                        .ForMember(dto => dto.Usuario.Id, model => model.MapFrom(m => m.IdUsuario));

                    cfg.CreateMap<AutenticacaoModel, UsuarioDto>();
                    
                    //Dto para Model
                    /*
                    cfg.CreateMap<Usuario, UsuarioDto>();
                    cfg.CreateMap<UsuarioDto, Usuario>();
                     */ 
                }
            );

            var mapper = config.CreateMapper();

            return mapper;

        }
    }
}