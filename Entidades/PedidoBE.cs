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
        private int id;
        private int nroPedido;
        private string estado;
        private DateTime fechaCreacion;
        private decimal subtotal;
        private decimal impuestos;
        private decimal total;

        private ReservaBE reserva;
        private FacturaBE factura;





        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NroPedido { get; set; }
        public string Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public virtual ReservaBE Reserva { get; set; }

        public virtual FacturaBE Factura { get; set; }

    }
}
