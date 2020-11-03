using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Vivero_G4.Models;

namespace Vivero_G4.Context
{
    public class ViveroContext : DbContext
    {
        public ViveroContext(DbContextOptions<ViveroContext> options) : base(options)
        {
        }

        public DbSet<Vivero> Viveros { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contenido> Contenidos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Vivero_G4.Models.Usuario> Usuario { get; set; }
        //public DbSet<Categoria> Categorias { get; set; }
        //public DbSet<TipoEntrega> TiposEntregas { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5L9GC2G\SQLEXPRESS;Database=ViveroG4;Trusted_Connection=True;");
        }*/
    }
}
