using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Auditoria
{
    [Table("PedidoHistorico")]
    public partial class PedidoHistoricoBE
    {
        #region Atributos privados
        private int id;
        private int nroPedido;
        private string estado;
        private DateTime fechaCreacion;
        private decimal subtotal;
        private decimal impuestos;
        private decimal total;
        private int reservaId;
        private int facturaId;
        private DateTime fechaModificacion;
        private string operacion;
        #endregion

        #region Propiedades publicas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NroPedido { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }

        //[ForeignKey("Reserva")]
        public int? ReservaId { get; set; }
        //public virtual ReservaBE Reserva { get; set; }

        //[ForeignKey("Factura")]
        public int? FacturaId { get; set; }
        //public virtual FacturaBE Factura { get; set; }

        public int? PedidoId { get; set; }

        public DateTime FechaModificacion { get; set; }
        public string Operacion { get; set; }
        #endregion
    }
}
