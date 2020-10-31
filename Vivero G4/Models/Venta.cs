using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VentaId { get; set; }
        public long NroTarjeta { get; set; }
        [Display(Name = "Fecha vencimiento")]
        public DateTime FecVencimiento { get; set; }
        public int CodSeguridad { get; set; }
        public string Domicilio { get; set; }
        public Usuario Usuario { get; set; }
        public List<Articulo> ArticulosVenta { get; set; }
        [EnumDataType(typeof(TipoEntrega))]
        public TipoEntrega TipoEntrega { get; set; }
    }
}
