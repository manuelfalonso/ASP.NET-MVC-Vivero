using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Vivero
    {
        //ATRIBUTOS
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ViveroId { get; set; }
        public string Nombre { get; set; }
        public Blog Blog { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Articulo> Stock { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
