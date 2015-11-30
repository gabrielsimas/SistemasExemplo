using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacao.Dto;
using Apresentacao.Web.Mvc.Models;

namespace Apresentacao.Web.Mvc.Montador
{
    public class MontaModeloDominioEViceVersa
    {
        #region Usuário

        public static UsuarioCadastroModel Monta(UsuarioDto dto)
        {
            if (dto != null)
            {
                UsuarioCadastroModel model = new UsuarioCadastroModel()
                {
                    Id = dto.Id,
                    Login = dto.Login,
                    NomeCompleto = dto.NomeCompleto,
                    Senha = dto.senha,
                    Estado = (Estado)dto.status
                };

                return model;
            }
            else
            {
                return null;
            }

        }
        public static AutenticacaoModel MontaAutenticacaoModel(UsuarioDto dto)
        {
            if (dto != null)
            {
                AutenticacaoModel model = new AutenticacaoModel()
                {
                    Id = dto.Id,
                    Login = dto.Login,
                    Senha = dto.senha
                };

                return model;
            }
            else
            {
                return null;
            }
        }

        public static UsuarioDto Monta(UsuarioCadastroModel model)
        {
            if (model != null)
            {
                UsuarioDto dto = new UsuarioDto()
                {
                    Id = model.Id,
                    Login = model.Login,
                    NomeCompleto = model.NomeCompleto,
                    senha = model.Senha,
                    status = (Status)model.Estado
                };
                return dto;
            }
            else
            {
                return null;
            }

        }
        public static UsuarioDto Monta(AutenticacaoModel model)
        {
            if (model != null)
            {
                UsuarioDto dto = new UsuarioDto()
                {
                    Login = model.Login,
                    senha = model.Senha
                };

                return dto;
            }
            else
            {
                return null;
            }
        }        

        #endregion

        #region Tarefa

        public static TarefaCadastroModel Monta(TarefaDto dto)
        {
            if (dto != null)
            {
                TarefaCadastroModel model = new TarefaCadastroModel()
                {
                    DataDaEntrega = dto.DataDaEntrega,
                    Descricao = dto.Descricao,
                    Estado = (EstadoTarefaModel)dto.Estado,
                    IdUsuario = dto.Usuario.Id,
                    Nome = dto.Nome
                };

                return model;
            }
            else
            {
                return null;
            }
        }
        public static TarefaEdicaoModel MontaTarefaEdicaoModel(TarefaDto dto)
        {
            if (dto != null)
            {
                TarefaEdicaoModel model = new TarefaEdicaoModel()
                {
                    DataDaEntrega = dto.DataDaEntrega,
                    Descricao = dto.Descricao,
                    Estado = (EstadoTarefaModel)dto.Estado,
                    IdUsuario = dto.Usuario.Id,
                    Nome = dto.Nome
                };

                return model;
            }
            else
            {
                return null;
            }
        }        

        public static TarefaListarModel MontaTarefaListarModel(TarefaDto dto)
        {
            if (dto != null)
            {
                TarefaListarModel model = new TarefaListarModel()
                {
                    DataDaEntrega = dto.DataDaEntrega,
                    Descricao = dto.Descricao,
                    Estado = (EstadoTarefaModel)dto.Estado,
                    Id = dto.Id,
                    IdUsuario = dto.Usuario.Id,
                    Nome = dto.Nome
                };

                return model;
            }
            else
            {
                return null;
            }
        }

        public static TarefaDto Monta(TarefaCadastroModel model)
        {
            if (model != null)
            {
                TarefaDto dto = new TarefaDto()
                {
                    DataDaEntrega = model.DataDaEntrega,
                    Descricao = model.Descricao,
                    Estado = (EstadoTarefa)model.Estado,
                    Nome = model.Nome
                };

                return dto;
            }
            else
            {
                return null;
            }
        }
        public static TarefaDto Monta(TarefaEdicaoModel model)
        {
            if (model != null)
            {
                TarefaDto dto = new TarefaDto()
                {
                    DataDaEntrega = model.DataDaEntrega,
                    Descricao = model.Descricao,
                    Estado = (EstadoTarefa)model.Estado,
                    Nome = model.Nome
                };

                return dto;
            }
            else
            {
                return null;
            }
        }
        
        public static TarefaDto Monta(TarefaExcluirModel model)
        {
            if (model != null)
            {
                TarefaDto dto = new TarefaDto()
                {
                    DataDaEntrega = model.DataDaEntrega,
                    Descricao = model.Descricao,
                    Estado = (EstadoTarefa)model.Estado,
                    Nome = model.Nome
                };

                return dto;
            }
            else
            {
                return null;
            }
        }
        public static TarefaDto Monta(TarefaListarModel model)
        {
            if (model != null)
            {
                TarefaDto dto = new TarefaDto()
                {
                    DataDaEntrega = model.DataDaEntrega,
                    Descricao = model.Descricao,
                    Estado = (EstadoTarefa)model.Estado,
                    Nome = model.Nome
                };

                return dto;
            }
            else
            {
                return null;
            }
        }


        public static ICollection<TarefaDto> Monta(ICollection<TarefaListarModel> models)
        {
            if (models != null && models.Count > 0 )
            {
                ICollection<TarefaDto> dtos = new List<TarefaDto>();

                foreach(TarefaListarModel linha in models)
                {
                    TarefaDto dto = new TarefaDto()
                    {
                        DataDaEntrega = linha.DataDaEntrega,
                        Descricao = linha.Descricao,
                        Estado = (EstadoTarefa)linha.Estado,
                        Id = linha.Id,
                        Nome = linha.Nome,
                        Usuario = new UsuarioDto()
                        {
                            Id = linha.IdUsuario
                        }
                    };
                    dtos.Add(dto);
                }

                return dtos;
            }
            else
            {
                return null;
            }
        }

        public static ICollection<TarefaListarModel> Monta(ICollection<TarefaDto> dtos)
        {
            if (dtos != null && dtos.Count > 0)
            {
                ICollection<TarefaListarModel> models = new List<TarefaListarModel>();

                foreach(TarefaDto linha in dtos)
                {                    
                    TarefaListarModel model = new TarefaListarModel()
                    {
                        DataDaEntrega = linha.DataDaEntrega,
                        Descricao = linha.Descricao,
                        Estado = (EstadoTarefaModel)linha.Estado,
                        Id = linha.Id,
                        IdUsuario = linha.Usuario.Id,
                        Nome = linha.Nome
                    };

                    models.Add(model);
                }

                return models;
            }
            else
            {
                return null;
            }
        }
        #endregion                                
    }
}