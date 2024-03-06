using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;


namespace Entidades
{
    [Table("Persona")]
    public partial class PersonaBE
    {
        private int id;
        private string nombre;
        private string apellido;
        private string dni;
        private string telefono;
        private string mail;
        private string direccion;
        private DateTime fechaNacimiento;
        private bool estadoActivo;



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20), MinLength(1)]
        public string Nombre { get; set; }
        [StringLength(20)]
        public string Apellido { get; set; }
        [StringLength(8)]
        public string DNI { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; }
        [StringLength(40)]
        public string Mail { get; set; }
        [StringLength(60)]
        public string Direccion { get; set; }

        [Column("FechaNacimiento", TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        public bool EstadoActivo { get; set; }
      
    }
}
