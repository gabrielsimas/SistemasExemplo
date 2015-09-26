using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;

namespace Dominio.Implementacao.Servico
{
    public class EditoraDominioServico: ServicoDeDominioBase<Editora>, IEditoraRepositorio
    {
        #region Atributos
        private IEditoraRepositorio editoraRepositorio;
        #endregion

        #region Construtores
        public EditoraDominioServico(IEditoraRepositorio editoraRepositorio)
            :base(editoraRepositorio)
        {
            this.editoraRepositorio = editoraRepositorio;
        }
        #endregion

        #region Métdos de Serviço de Domínio
        #endregion
    }
}
