using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("DetalleFactura")]
    public partial class DetalleFacturaBE
    {

        private int id;
        private string nombreProducto;
        private int cantidadPedida;
        private decimal subtotal;
        private decimal impuestos;
        private decimal total;
        private ProductoBE producto;
        private FacturaBE factura;




        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadPedida { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }

        public virtual ProductoBE Producto { get; set; }
        public virtual FacturaBE Factura { get; set; }
    }
}
