using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Seguridad
{
    [Table("UsuarioGrupo")]
    public class UsuarioGrupoBE
    {
        [Key]
        public int Id { get; set; }

        //public int UsuarioId { get; set; }
        public UsuarioBE Usuario { get; set; }
        //public int GrupoId { get; set; }
        public GrupoBE Grupo { get; set; }
    }
}

