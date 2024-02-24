using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Habitacion")]
    public partial class HabitacionBE
    {
        #region Atributos privados
        private int id;
        private int piso;
        private int nroHabitacion;
        private string estado;
        private decimal precioDiario;
        private string tipoCamas;
        private string tipoHabitacion;

        #endregion

        #region Propiedades publicas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Piso { get; set; }
        public int NroHabitacion { get; set; }
        public string Estado { get; set; }
        public decimal PrecioDiario { get; set; }
        public string TipoCamas { get; set; }
        public string TipoHabitacion { get; set; }
        #endregion

    }
}
