using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Vivero_G4.Models
{
    public class Contenido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContenidoId { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public List<Comentario> Comentarios { get; set; }

        public void NuevoComentario() { }
    }
}
