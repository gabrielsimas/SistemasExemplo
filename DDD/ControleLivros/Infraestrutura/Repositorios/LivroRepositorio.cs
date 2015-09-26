using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Framework.Arquitetura.DDD.InfraEstrutura.Repositorios.EF;
using Framework.Arquitetura.DDD.Dominio.Interfaces.Repositorios;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Infraestrutura.DataSource;

namespace Infraestrutura.Repositorios
{
    public class LivroRepositorio: RepositorioBase<Livro,FonteDeDados>, ILivroRepositorio
    {

    }
}
