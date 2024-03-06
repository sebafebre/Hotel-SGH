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

        private int id;
        private string puesto;
        private string cargo;
        private DateTime fechaIngreso;
        private PersonaBE persona;

        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Puesto { get; set; }

        public string Cargo { get; set; }

        public DateTime FechaIngreso { get; set; }

        public virtual PersonaBE Persona { get; set; }

    }
}
