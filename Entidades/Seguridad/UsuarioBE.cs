using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    [Table("Usuario")]
    public partial class UsuarioBE
    {
        #region Atributos privados
        private int id;
        private string nombre;
        private string clave;
        #endregion

        #region Propiedades publicas

        [Key]
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public EmpleadoBE Empleado { get; set; }
        #endregion


        //Propiedad estatica para acceder al usuario desde cualquier frm
        public static string usaurioLogueado { get; set; }


    }
}
