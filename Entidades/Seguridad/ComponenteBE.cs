using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Componente")]
    public  class ComponenteBE
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        /*
        protected int Id { get; set; }
        protected string Nombre { get; set; }
        
        
        // Constructor
        public ComponenteBE(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public ComponenteBE()
        {
        }

        
        public abstract void Crear(ComponenteBE c);
        public abstract void Eliminar(ComponenteBE c);
        public abstract void Listar(int depth);

        public int ObtenerId()
        {
            return Id;
        }*/

    }

    





}
