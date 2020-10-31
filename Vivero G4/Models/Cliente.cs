using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Cliente : Usuario
    {
        public override void ActualizarDatos()
        {
            throw new NotImplementedException();
        }

        public void RealizarCompra()
        {
            throw new NotImplementedException();
        }
    }
}
