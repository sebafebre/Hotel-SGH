using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Pedido")]
    public partial class PedidoBE
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        //Eliminar Cliente 
        public string Cliente { get; set; }



        public int NroPedido { get; set; }
        public string Estado { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FechaCreacion { get; set; }
        public decimal Total { get; set; }
        public virtual ReservaBE Reserva { get; set; }

    }
}
