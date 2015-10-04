using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Entidade
{
    [Serializable]
    public class Livro: Entidade
    {
        
        #region Atributos
        
        private String isbn;
        private String titulo;
        private String genero;
        private String sinopse;
        private String autor;       
        private Editora editora;       

        #endregion

        #region Construtores
        public Livro()
        {

        }
        public Livro(Nullable<long> id,String isbn,String titulo,String genero,String sinopse,String autor)
        {
            this.Id = id;
            this.isbn = isbn;
            this.titulo = titulo;
            this.genero = genero;
            this.sinopse = sinopse;
            this.autor = autor;
        }

        #endregion

        #region Propriedades        

        public virtual String Isbn
        {
            get { return this.isbn; }
            set { this.isbn = value; }
        }

        public virtual String Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public virtual String Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }

        public virtual String Sinopse
        {
            get { return this.sinopse; }
            set { this.sinopse = value; }
        }

        public virtual String Autor
        {
            get { return this.autor; }
            set { this.autor = value; }
        }

        public virtual Editora Editora
        {
            get { return this.editora; }
            set { this.editora = value; }
        }
        #endregion

        #region Sobrescritas do Papai Object        

        public override string ToString()
        {
            System.Reflection.PropertyInfo[] propriedades;
            propriedades = GetType().GetProperties(System.Reflection.BindingFlags.Public);
            return propriedades.ToString();
        }

        #endregion  
                
    }
}
