using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Entidade.Fabrica;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Infraestrutura.EF.ContextoBD;

namespace ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao
{
    public class EditoraRepositorio: UnityOfWork, IEditoraRepositorio
    {
        #region Atributos

        protected ContextoDb conexao;

        #endregion

        #region Construtores
        public EditoraRepositorio(ContextoDb contexto)
        {
            this.conexao = contexto;
        }

        #endregion
        
        public void Alterar(Editora entidade)
        {
            conexao.Entry(entidade).State = EntityState.Modified;
        }

        public Editora BuscarPorId(long? id)
        {
            return conexao.Set<Editora>().Find(id);
        }

        public ICollection<Editora> BuscarTodos()
        {
            return conexao.Set<Editora>().ToList();
        }        

        public void Excluir(Editora entidade)
        {
            conexao.Entry(entidade).State = EntityState.Deleted;
        }

        public Editora FiltrarUmPor(Func<Editora, bool> predicado)
        {
            return conexao.Editora.Where(predicado).Single();
        }

        public ICollection<Editora> FiltrarVariosPor(Func<Editora, bool> predicado)
        {
            return conexao.Editora.Where(predicado).ToList();
        }

        public void Salvar(Editora entidade)
        {
            conexao.Entry(entidade).State = EntityState.Added;
        }
        public void Dispose()
        {
            conexao.Dispose();
        }
    }
}
