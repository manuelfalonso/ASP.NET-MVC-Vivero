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
        Plantas,
        Semillas,
        [Display(Name = "Accesorios de Jardín")]
        ACCESORIOS_JARDIN,
        Sustratos,
        Macetas,
        [Display(Name = "Agroquímicos")]
        AGROQUIMICOS
    }
}
