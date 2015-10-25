using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Persistencia.DataSource
{
    public class ConexaoDeDados: DbContext
    {
        public ConexaoDeDados()
            :base("sgt")
        {

        }

        public DbSet<Usuario> TbUsuario { get; set; }
        public DbSet<Tarefa> TbTarefa { get; set; }
    }
}
