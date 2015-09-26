using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Framework.Arquitetura.DDD.Dominio.Interfaces.ServicosDeDominio;

namespace Dominio.Interfaces.ServicosDominio
{
    public interface IServicoDominioLivro: IServicoDeDominioBase<Livro>
    {
    }
}
