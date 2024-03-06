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
    public class GrupoBE 
    {
        private int id;
        private ComponenteBE componente;


        [Key]
        public int Id { get; set; }

        public ComponenteBE Componente { get; set; }

    }
}
