using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestrutura.ORM.EF.ContextoDB;

namespace Teste.RefactDDD.Comum.EntityFrameworkThings
{
    /// <summary>
    /// Classe para DbContext Híbrido.
    /// Genéticamente modificado para evitar que as gravações sejam colocadas no Banco de Dados
    /// Após o SaveChanges, o mesmo irá efetuar um rollback no Banco.
    /// Mantendo os testes sempre íntegros.
    /// Isso é muito importante para integração e entrega contínuos através
    /// dos testes que passaram
    /// </summary>    
    public class DbContextParaTeste: Conexao
    {

    }
}
