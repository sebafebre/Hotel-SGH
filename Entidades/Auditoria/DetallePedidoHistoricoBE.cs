using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Auditoria
{
    [Table("DetallePedidoHistorico")]
    public partial class DetallePedidoHistoricoBE
    {
        #region Atributos privados
        private int id;
        private string nombreProducto;
        private int cantidadPedida;
        private decimal subtotal;
        private decimal impuestos;
        private decimal total;
        private int productoId;
        private int pedidoId;
        private DateTime fechaModificacion;
        private string operacion;
        #endregion

        #region Propiedades publicas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadPedida { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }

        //[ForeignKey("Producto")]
        public int? ProductoId { get; set; }
        //public virtual ProductoBE Producto { get; set; }


        //[ForeignKey("Pedido")]
        public int? PedidoId { get; set; }
        //public virtual PedidoBE Pedido { get; set; }


        public int? DetallePedidoId { get; set; }



        public DateTime FechaModificacion { get; set; }
        public string Operacion { get; set; }
        #endregion
    }
}
