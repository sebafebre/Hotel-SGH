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
    [Table("UsuarioGrupoComponente")]
    public class UsuarioGrupoComponenteBE
    {
        private int id;
        private UsuarioBE usuario;
        private GrupoBE componente;


        [Key]
        public int Id { get; set; }

        //public int UsuarioId { get; set; }
        public UsuarioBE Usuario { get; set; }
        //public int GrupoId { get; set; }
        public ComponenteBE Componente { get; set; }
    }
}

