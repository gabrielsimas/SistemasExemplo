using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.DataSource
{
    public class FonteDeDados: DbContext
    {
        #region Atributos
        #endregion
        #region Construtores
        public FonteDeDados()
            :base(ConfigurationManager.ConnectionStrings["Exercicio01"].ConnectionString)
        {

        }
        #endregion
    }
}
