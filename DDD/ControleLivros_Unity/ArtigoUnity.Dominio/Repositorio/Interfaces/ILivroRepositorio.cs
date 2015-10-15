using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces.Base;
using ArtigoUnity.Infraestrutura.EF.Repositorio.Interfaces;

namespace ArtigoUnity.Dominio.Repositorio.Interfaces
{
    public interface ILivroRepositorio:IRepositorioBase<Livro>, IUnitOfWork
    {

    }
}
