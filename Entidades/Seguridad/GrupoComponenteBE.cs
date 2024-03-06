using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("GrupoComponente")]
    public class GrupoComponenteBE
    {

        private int id;
        private GrupoBE grupo;
        private ComponenteBE componente;



        [Key]
        public int Id { get; set; }
        public virtual GrupoBE Grupo { get; set; }
        public virtual ComponenteBE Componente { get; set; }
    }
}
