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
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{1,40}$",
         ErrorMessage = "Caracteres inválidos.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{1,40}$",
         ErrorMessage = "Caracteres inválidos.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        [RegularExpression(@"^[0-9-]{9,15}$",
         ErrorMessage = "Formato 11-2222-3333")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [RegularExpression(@"(?!^[0-9]$)(?!^[a-zA-Z]$)^([a-zA-Z0-9]{8,15})$",
         ErrorMessage = "La contraseña debe contener entre 8 y 15 caracteres que contengan letras y números")]
        public string Contraseña { get; set; }
        public bool EsAdmin { get; set; }
        public List<Articulo> ArticulosFavoritos { get; set; }

     
    }
}
