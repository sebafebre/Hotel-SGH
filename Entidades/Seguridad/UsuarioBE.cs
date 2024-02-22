using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Usuario")]
    public partial class UsuarioBE
    {

        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public EmpleadoBE Empleado { get; set; }

        public UsuarioBE()
        {
            //Grupos = new List<GrupoBE>();
        }
    }
}
