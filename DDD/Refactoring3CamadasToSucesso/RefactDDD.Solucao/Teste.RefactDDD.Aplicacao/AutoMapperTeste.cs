using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Teste.RefactDDD.Aplicacao.Mappers;
using Dominio.Entidade;
using Aplicacao.Dto;
using AutoMapper;
using Apresentacao.Mvc5.Models;

namespace Teste.RefactDDD.Aplicacao
{
    /// <summary>
    /// Summary description for AutoMapperTeste
    /// </summary>
    [TestClass]
    public class AutoMapperTeste
    {
        #region Atributos

        private TestContext testContextInstance;
        private IMapper mapper;
        
        #endregion

        #region Construtores

        public AutoMapperTeste()
        {

        }

        #endregion

        #region Inicialização e Destruição

        [TestInitialize]
        public void Init()
        {
            mapper = AutoMapperConfig.RegisterProfiles();
        }


        #endregion

        #region Propriedades

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #endregion

        #region Testes Unitários

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Entidade Para Dto")]
        [Description("Testa a capacidade do Automapper de transcrever a entidade usuário para UsuarioDto")]
        public void UsuarioParaUsuarioDtoSemFilho()
        {
            UsuarioDto dto = new UsuarioDto();

            Usuario usuario = new Usuario()
            {
                Login = "gabrielsimas",
                NomeCompleto = "Luís Gabriel N. Simas",
                Senha = "teste,123",
                Status = Dominio.Entidade.Status.ativo
            };

            dto = mapper.Map<UsuarioDto>(usuario);

            Assert.IsTrue(!String.IsNullOrEmpty(dto.Login));
        }

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Entidade Para Dto")]
        [Description("Testa a capacidade do Automapper de transcrever a entidade usuário para UsuarioDto")]
        public void UsuarioParaUsuarioDtoComFilho()
        {
            UsuarioDto dto = new UsuarioDto();

            ICollection<Tarefa> tarefas = new List<Tarefa>();           

            Usuario usuario = new Usuario()
            {
                Login = "gabrielsimas",
                NomeCompleto = "Luís Gabriel N. Simas",
                Senha = "teste,123",
                Status = Dominio.Entidade.Status.ativo,
                Tarefas = new List<Tarefa>()
                {
                    new Tarefa()
                    {
                        DataDaEntrega = DateTime.Now,
                        Descricao = "UkjjkbHUHAKKACANCKNANC",
                        Estado = Dominio.Entidade.EstadoTarefa.EmAberto,
                        Nome = "KFCknacklaNNASLNLADNSLSNDKL",
                        Usuario = new Usuario(){
                            Id = 9
                        }
                    },
                    new Tarefa()
                    {
                        DataDaEntrega = DateTime.Now,
                        Descricao = "UHUHAKKACANCKNANC",
                        Estado = Dominio.Entidade.EstadoTarefa.EmAberto,
                        Nome = "KFKNNASLNLADNSLSNDKL",
                        Usuario = new Usuario(){
                            Id = 9
                        }
                    }
                }
            };

            dto = mapper.Map<UsuarioDto>(usuario);

            Assert.IsTrue(!String.IsNullOrEmpty(dto.Login));
        }

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Entidade Para Dto")]
        [Description("Testa a capacidade do Automapper de transcrever a entidade Tarefa para TarefaDto")]
        public void TarefaParaTarefaDto()
        {
            TarefaDto dto = new TarefaDto();

            Tarefa tarefa = new Tarefa()
            {
                DataDaEntrega = DateTime.Now,
                Descricao = "Teste de transcrição da Entidade Tarefa para o Dto de Tarefa",
                Estado = Dominio.Entidade.EstadoTarefa.EmAberto,
                Nome = "Testa a Transcrição da entidade Tarefa",
                Usuario = new Usuario()
                {
                    Id = 9
                }
            };

            dto = mapper.Map<TarefaDto>(tarefa);

            Assert.IsTrue(!String.IsNullOrEmpty(dto.Nome) && dto.Usuario.Id.HasValue);
        }

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Dto Para Entidade")]
        [Description("Testa a capacidade do Automapper de transcrever a entidade Tarefa para TarefaDto")]
        public void TarefaDtoParaTarefa()
        {
            Tarefa tarefa = new Tarefa();

            TarefaDto dto = new TarefaDto()
            {
                DataDaEntrega = DateTime.Now,
                Descricao = "Transcrever o dto de Tarefas para a entidade",
                Estado = global::Aplicacao.Dto.EstadoTarefa.EmAberto,
                Nome = "Transcrever o dto de tarefas -> entidade",
                Usuario = new UsuarioDto()
                {
                    Id = 9
                }
            };

            tarefa = mapper.Map<Tarefa>(dto);

            Assert.IsTrue(!String.IsNullOrEmpty(dto.Nome) && dto.Usuario.Id.HasValue);                
        }

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Model Para Dto")]
        [Description("Testa a capacidade do Automapper de transcrever a Model TarefaModelCadastro para TarefaDto")]
        public void TarefaCadastroModelParaTarefaDto()
        {
            TarefaDto dto = new TarefaDto();
            TarefaCadastroModel model = new TarefaCadastroModel()
            {
                DataDaEntrega = DateTime.Now,
                Descricao = "Transcrição de Model para Dto",
                Estado = EstadoTarefaModel.EmAberto,
                IdUsuario = 1,
                Nome = "Transcrição de Model para Dto"
            };

            dto = mapper.Map<TarefaDto>(model);

            Assert.IsTrue(!String.IsNullOrEmpty(dto.Nome) && dto.Usuario.Id.HasValue);

        }

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Model Para Dto")]
        [Description("Testa a capacidade do Automapper de transcrever a Model TarefaModelCadastro para TarefaDto")]
        public void TarefaDtoParaTarefaCadastroModel()
        {
            TarefaCadastroModel model = new TarefaCadastroModel();
            TarefaDto dto = new TarefaDto()
            {
                DataDaEntrega = DateTime.Now,
                Descricao = "Transcrição de Model para Dto",
                Estado = global::Aplicacao.Dto.EstadoTarefa.EmAberto,                
                Nome = "Transcrição de Model para Dto",
                Usuario = new UsuarioDto()
                {
                    Id = 9
                }
            };

            model = mapper.Map<TarefaCadastroModel>(dto);

            Assert.IsTrue(!String.IsNullOrEmpty(model.Nome) && model.IdUsuario.HasValue);

        }

        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Dto para Entidade")]
        [Description("Testa a capacidade do Automapper de transcrever a Model TarefaModelCadastro para TarefaDto")]
        public void ListaTarefasDtoParaListaTarefas()
        {

            IList<Tarefa> entidades = new List<Tarefa>();
            
            IList<TarefaDto> tarefas = new List<TarefaDto>()
            {
                new TarefaDto()
                {
                    DataDaEntrega = DateTime.Now,
                    Descricao = "UkjjkbHUHAKKACANCKNANC",
                    Estado = global::Aplicacao.Dto.EstadoTarefa.EmAberto,
                    Nome = "KFCknacklaNNASLNLADNSLSNDKL",
                    Usuario = new UsuarioDto(){
                        Id = 9
                    }
                },
                new TarefaDto()
                {
                    DataDaEntrega = DateTime.Now,
                    Descricao = "UHUHAKKACANCKNANC",
                    Estado = global::Aplicacao.Dto.EstadoTarefa.EmAberto,
                    Nome = "KFKNNASLNLADNSLSNDKL",
                    Usuario = new UsuarioDto(){
                        Id = 9
                    }
                }
            };

            entidades = mapper.Map<IList<TarefaDto>, IList<Tarefa>>(tarefas);

            Assert.IsTrue(entidades.Count > 0);

        }
        
        [TestMethod]
        [TestCategory("Aplicação - AutoMapper - Model para Dto")]
        [Description("Testa a capacidade do Automapper de transcrever a Model AutenticacaoModel para UsuarioDto")]
        public void AutenticacaoModelParaUsuarioDto()
        {
            UsuarioDto dto = new UsuarioDto();

            AutenticacaoModel model = new AutenticacaoModel()
            {
                Login = "gabrielsimas",
                Senha = "@abc,123"
            };

            dto = mapper.Map<UsuarioDto>(model);

            Assert.IsTrue(!String.IsNullOrEmpty(dto.Login) && !String.IsNullOrEmpty(dto.senha));
        }


        public void UsuarioDtoParaAutenticacaoModel()
        {

        }

        #endregion                              
    }
}

