using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Contenido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContenidoId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{1,60}$",
         ErrorMessage = "Caracteres inválidos.")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{1,2000}$",
         ErrorMessage = "Caracteres inválidos.")]
        public string Texto { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
