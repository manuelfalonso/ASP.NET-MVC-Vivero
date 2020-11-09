using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Vivero_G4.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VentaId { get; set; }
        [Required]
        [CreditCardAttribute]
        public long NroTarjeta { get; set; }
        [Display(Name = "Fecha vencimiento")]
        [Required]
        [RegularExpression(@"(0[1 - 9] | 1[0 - 2])/[0-9]{2}")]
        public DateTime FecVencimiento { get; set; } //CAMBIAR TIPO DE DATO DE DATETIME A STRING
        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public int CodSeguridad { get; set; }
        public string Domicilio { get; set; }
        public Usuario Usuario { get; set; }
        public List<Articulo> ArticulosVenta { get; set; }
        [EnumDataType(typeof(TipoEntrega))]
        public TipoEntrega TipoEntrega { get; set; }
    }
}
