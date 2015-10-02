using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Dominio.Servico.Interfaces;

namespace ArtigoUnity.Dominio.Servico.Implementacao
{
    public class EditoraServico: IEditoraServico, IDisposable
    {
        #region Atributos
        private IEditoraRepositorio editoraRepositorio;
        #endregion

        #region Construtores
        public EditoraServico(IEditoraRepositorio repo)
        {
            this.editoraRepositorio = repo;
        }
        #endregion

        #region Método de Serviço
        public void Cadastrar(Editora entidade)
        {
            this.editoraRepositorio.Salvar(entidade);
        }

        public void Alterar(Editora entidade)
        {
            this.editoraRepositorio.Alterar(entidade);
        }

        public void Excluir(Editora entidade)
        {
            this.editoraRepositorio.Excluir(entidade);
        }

        public Editora BuscarPorId(long? id)
        {
            return this.editoraRepositorio.BuscarPorId(id);
        }

        public ICollection<Editora> ListarTudo()
        {
            return this.editoraRepositorio.BuscarTodos();
        }

        public void Dispose()
        {
            this.editoraRepositorio.Dispose();
        }
        #endregion
    }
}
