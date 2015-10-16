using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngularJS.Web.Mvc.Models
{
    public class CategoriaCadastroModel
    {        
        public String Nome { get; set; }
    }

    public class CategoriaConsultaModel
    {
        public int Id { get; set; }
        public String Nome { get; set; }
    }
}