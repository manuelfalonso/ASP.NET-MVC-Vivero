using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComentarioId { get; set;}
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{1,1000}$",
         ErrorMessage = "Caracteres inválidos.")]
        public string Texto { get; set;}
    }
}
