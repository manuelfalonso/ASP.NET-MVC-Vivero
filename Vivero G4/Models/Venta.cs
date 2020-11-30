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
        [Required(ErrorMessage = "Debe ingresar el número de tarjeta")]
        public long NroTarjeta { get; set; }
        [Display(Name = "Fecha vencimiento")]
        [Required(ErrorMessage = "Debe ingresar la fecha de vencimiento")]
        //[RegularExpression(@"(0[1 - 9] | 1[0 - 2])/[0-9]{2}", ErrorMessage = "la fecha debe ser válida")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM-YY}", ApplyFormatInEditMode = true)]
        public DateTime FecVencimiento { get; set; } //CAMBIAR TIPO DE DATO DE DATETIME A STRING
        [Required(ErrorMessage = "Debe ingresar el código de seguridad")]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "el código de seguridad debe ser válido")]

        public int CodSeguridad { get; set; }
        [Required(ErrorMessage = "Debe ingresar su domicilio")]
        public string Domicilio { get; set; }
        public Usuario Usuario { get; set; }
        public List<Articulo> ArticulosVenta { get; set; }
        [EnumDataType(typeof(TipoEntrega))]
        public TipoEntrega TipoEntrega { get; set; }
    }
}
