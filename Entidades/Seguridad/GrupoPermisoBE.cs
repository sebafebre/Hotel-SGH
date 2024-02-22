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
    [Table("GrupoPermiso")]
    public class GrupoPermisoBE
    {
        [Key]
        public int Id { get; set; }
        //public int GrupoId { get; set; }
        //public int PermisoId { get; set; }

        public virtual GrupoBE Grupo { get; set; }
        public virtual PermisoBE Permiso { get; set; }
    }
}
