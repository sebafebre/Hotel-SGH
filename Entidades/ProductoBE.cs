using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Producto")]
    public partial class ProductoBE
    {
        /*
        public ProductoBE()
        {
            this.DetallesFactura = new HashSet<DetalleFacturaBE>();
            this.DetallesPedido = new HashSet<DetallePedidoBE>();
        }*/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadStock { get; set; }
        public int PrecioUnitario { get; set; }

        //public virtual ICollection<DetalleFacturaBE> DetallesFactura { get; set; }
        //public virtual ICollection<DetallePedidoBE> DetallesPedido { get; set; }
    }
}
