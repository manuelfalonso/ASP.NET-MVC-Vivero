using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vivero_G4.Models
{
    public enum Categoria
    {
        [Display(Name = "PLANTAS")]
        PLANTAS,
        [Display(Name = "SEMILLAS")]
        SEMILLAS,
        [Display(Name = "ACCESORIOS_JARDIN")]
        ACCESORIOS_JARDIN,
        [Display(Name = "SUSTRATOS")]
        SUSTRATOS,
        [Display(Name = "MACETAS")]
        MACETAS,
        [Display(Name = "AGROQUIMICOS")]
        AGROQUIMICOS
    }
}
