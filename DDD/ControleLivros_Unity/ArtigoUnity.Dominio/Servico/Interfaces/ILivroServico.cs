using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Servico.Interfaces.Base;

namespace ArtigoUnity.Dominio.Servico.Interfaces
{
    public interface ILivroServico: IBaseServicoCadastrar<Livro>, IBaseServicoAlterar<Livro>, IBaseServicoApagar<Livro>, IBaseServicoListar<Livro>
    {        
        Livro BuscarLivroPorIsbn(String isbn);
        ICollection<Livro> BuscarLivrosPorTrechoDoTitulo(String trecho);
        ICollection<Livro> BuscarLivrosPorGenero(String genero);
        ICollection<Livro> BuscarLivrosPorAutor(String nomeAutor);
        ICollection<Livro> BuscarLivrosPorEditora(String nomeEditora);
    }
}
