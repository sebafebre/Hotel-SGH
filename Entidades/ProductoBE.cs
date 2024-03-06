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
        private int id;
        private string nombreProducto;
        private int cantidadStock;
        private int precioUnitario;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadStock { get; set; }
        public int PrecioUnitario { get; set; }
    }
}
