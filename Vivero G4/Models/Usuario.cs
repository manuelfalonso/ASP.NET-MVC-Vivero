using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public abstract class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public bool EsAdmin { get; set; }
        public List<Articulo> ArticulosFavoritos { get; set; }

        abstract public void ActualizarDatos();
    }
}
