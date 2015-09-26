using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    /// <summary>
    /// Entidade Autor
    /// </summary>
    public class Autor
    {               
        #region Construtores
        public Autor()
        {

        }        
        #endregion

        #region Propriedades

        public virtual Nullable<long> Id {get; set;}
        public virtual String Nome {get; set;}
        public virtual ICollection<Livro> Livros { get; set; }
        

        #endregion

        #region Sobrescritas do Papai Object

        public override bool Equals(object objeto)
        {
            if (objeto is Autor)
            {
                Autor autor = (Autor)objeto;
                if (autor.Id.HasValue && this.Id.HasValue)
                {
                    return autor.Id.Value.Equals(this.Id.Value);
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.HasValue ? this.Id.Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            System.Reflection.PropertyInfo[] propriedades;
            propriedades = GetType().GetProperties(System.Reflection.BindingFlags.Public);
            return propriedades.ToString();
        }

        #endregion  
                 
    }
}
