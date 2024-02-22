using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entidades
{
    [Table("Grupo")]
    public class GrupoBE //: ComponenteBE
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }


        /*
        public ComponenteBE Componente { get; set; }

        public GrupoBE()
        {
            // Constructor sin parámetros
        }

        
        public GrupoBE(string nombre)
        {
            Nombre = nombre;
        }


        
        public GrupoBE(string Nombre) : base(Nombre)
        {
        }
        

        // Sobrescribe el método de la clase base para agregar un grupo a la base de datos
        //public override void AgregarComponente(){}
        public override void Crear(ComponenteBE g)
        {
            

        }
        
        public override void Eliminar(ComponenteBE g)
        {
            
        }
        public override void Listar(int depth)
        {
            
        }*/
    }
}
