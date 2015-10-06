using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArtigoUnity.Dominio.Entidade;

namespace ArtigoUnity.Infraestrutura.EF.Mapeamento.Comum
{
    public class LivroId: Livro
    {
        private Nullable<long> idEditora;

        public virtual Nullable<long> IdEditora
        {
            get { return this.idEditora; }
            set { this.idEditora = value; }
        }

        public LivroId(Nullable<long> id, String isbn, String titulo, String genero, String sinopse, String autor, Nullable<long> idEditora, Editora editora) :
            base(id, isbn,titulo,genero,sinopse,autor)
        {
            this.Autor = autor;
            this.Editora = editora;
            this.Genero = genero;
            this.Id = id;
            this.idEditora = idEditora;
            this.Isbn = isbn;
            this.Sinopse = sinopse;
            this.Titulo = titulo;            
        }

        public LivroId()
            : base()
        {

        }

        public override string ToString()
        {
            System.Reflection.PropertyInfo[] propriedades;
            propriedades = GetType().GetProperties(System.Reflection.BindingFlags.Public);
            return propriedades.ToString();
        }

    }
}
