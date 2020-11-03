using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vivero_G4
{
    public enum TipoEntrega
    {
        [Display(Name = "Retiro en local")]
        RETIRO_LOCAL,
        [Display(Name = "Envio a domicilio")]
        ENVIO_DOMICILIO
    }
}
