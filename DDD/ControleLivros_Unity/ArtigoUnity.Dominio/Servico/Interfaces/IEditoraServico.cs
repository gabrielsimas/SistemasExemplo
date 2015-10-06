using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Servico.Interfaces.Base;

namespace ArtigoUnity.Dominio.Servico.Interfaces
{
    public interface IEditoraServico : IBaseServicoCadastrar<Editora>, IBaseServicoAlterar<Editora>, IBaseServicoApagar<Editora>, IBaseServicoListar<Editora>, IBaseServicoFiltrarPor<Editora>, IDisposable
    {
        Editora BuscarPorNome(String nomeEditora);
        ICollection<Editora> BuscarPorNomeLike(String nomeEditora);
    }
}
