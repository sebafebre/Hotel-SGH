using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entidades
{
    [Table("Permiso")]
    public class PermisoBE //: ComponenteBE
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ComponenteBE Componente { get; set; }
        //
        //
        //
        //public string Nombre { get; set; }

        /*
        public PermisoBE(string Nombre): base(Nombre)
        {
        }
        public override void Crear(ComponenteBE p)
        {
            
        }
        public override void Eliminar(ComponenteBE p)
        {
            
        }
        public override void Listar(int depth)
        {
            
        }

        */





        // Sobrescribe el método de la clase base para agregar un permiso a la base de datos
        //public override void AgregarComponente(){}
    }
}
