using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Factura")]
    public partial class FacturaBE
    {
        /*
        public FacturaBE()
        {
            this.DetallesFactura = new HashSet<DetalleFacturaBE>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Emisor { get; set; }
        public string TipoFactura { get; set; }
        public int NroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Estado { get; set; }

        //public virtual ICollection<DetalleFacturaBE> DetallesFactura { get; set; }
        public virtual EmpleadoBE Empleado { get; set; }
        public virtual PedidoBE Pedido { get; set; }
    }
}
