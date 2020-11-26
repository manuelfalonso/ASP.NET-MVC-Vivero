using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticuloId { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]{1,40}$",
         ErrorMessage = "Caracteres inválidos.")]
        public string Nombre { get; set; }
        [Range(0, 999999)]
        public float Precio { get; set; }
        [Range(0, 999999)]
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
        [EnumDataType(typeof(Categoria))]
        public Categoria Categoria { get; set; }
    }
}
