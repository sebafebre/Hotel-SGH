using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Reserva")]
    public class ReservaBE
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int NroReserva { get; set; }

        [Column("FechaLlegada", TypeName = "date")]
        public DateTime FechaLlegada { get; set; }

        [Column("FechaIda", TypeName = "date")]
        public DateTime FechaIda { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public virtual ClienteBE Cliente { get; set; }
        public virtual HabitacionBE Habitacion { get; set; }
    }
}
