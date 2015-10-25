using System;
using DAL.Entidades;
using DAL.Persistencia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teste.DAL
{
    [TestClass]
    public class TesteTarefaDao
    {
        #region Atributos

        private TarefaDao dao;

        #endregion
        
        #region Testes unitários

        [TestMethod]
        [Description("Grava uma tarefa")]
        [TestCategory("DAL - TarefaDao - CRUD")]
        public void GravarTarefa()
        {
            int usuarioId = 1;
            Tarefa entregarArtigo = new Tarefa()
            {
                DataDeEntrega = new DateTime(2015, 10, 30),
                Descricao = "Entregar Artigo de refactoring para o Joel",
                IdUsuario = usuarioId,
                Nome = "Entregar Artigo"                
            };

            using(dao = new TarefaDao())
            {
                dao.Criar(entregarArtigo);
            }

            Assert.IsTrue(entregarArtigo.Id > 0);
        }

        #endregion
    }
}
