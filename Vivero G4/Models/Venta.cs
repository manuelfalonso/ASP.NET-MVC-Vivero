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
        [RegularExpression(@"[\d][0-9]{15}",
         ErrorMessage = "Debe ingresar un número de tarjeta valido")]
        public long NroTarjeta { get; set; }
        [Display(Name = "Fecha vencimiento")]
        [Required(ErrorMessage = "Debe ingresar la fecha de vencimiento")]
        [RegularExpression(@"^(0[1-9]|1[0-2])/([2-9][0^abc$-9])$",
         ErrorMessage = "Formato MM/AA")]
        public string FecVencimiento { get; set; } //CAMBIAR TIPO DE DATO DE DATETIME A STRING
        [Required(ErrorMessage = "Debe ingresar el código de seguridad")]
        [RegularExpression(@"^[0-9]{3}$",
         ErrorMessage = "Debe ingresar un codigo de seguridad valido")]
        public int CodSeguridad { get; set; }
        [Required(ErrorMessage = "Debe ingresar su domicilio")]
        public string Domicilio { get; set; }
        //public Usuario Usuario { get; set; } //REEMPLAZO PARA DEJARLO COMO LA BASE DE DATOS. UN INT IDUSUARIO
        public int UsuarioId { get; set; }
        //public List<Articulo> ArticulosVenta { get; set; } REEMPLAZO PARA PERMITIR CRUZAR CON TABLA ARTICULO. LIST NO SIRVE EN LA BASE DE DATOS
        //public Articulo Articulo { get; set; }
        public int ArticuloId { get; set; }
        [EnumDataType(typeof(TipoEntrega))]
        public TipoEntrega TipoEntrega { get; set; }
    }
}
