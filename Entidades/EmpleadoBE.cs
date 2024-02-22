using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Empleado")]
    public partial class EmpleadoBE
    {
        /*
        public EmpleadoBE()
        {
            this.Facturas = new HashSet<FacturaBE>();
            this.Usuarios = new HashSet<UsuarioBE>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Puesto { get; set; }

        public string Cargo { get; set; }

        public DateTime FechaIngreso { get; set; }

        public virtual PersonaBE Persona { get; set; }

        //public virtual ICollection<FacturaBE> Facturas { get; set; }
        //public virtual ICollection<UsuarioBE> Usuarios { get; set; }
    }
}
