using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Infraestrutura.EF.ContextoBD;

namespace ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao
{
    public class EditoraRepositorio: RepositorioBase<Editora,ContextoDb>, IEditoraRepositorio
    {
        public EditoraRepositorio(ContextoDb contexto)
            :base(contexto)
        {

        }
    }
}
