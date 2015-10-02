using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Framework.Arquitetura.DDD.InfraEstrutura.Repositorios.EF;
using Infraestrutura.Configuracao.EF.FonteDeDados;


namespace Infraestrutura.Repositorios.EF
{
    public class ContatoRepositorio
        :RepositorioBase<Contato,ContextoDeBanco>
    {
    }
}
