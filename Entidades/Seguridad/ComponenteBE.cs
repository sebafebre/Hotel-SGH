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

        private int id;
        private string nombre;


        public int Id { get; set; }
        public string Nombre { get; set; }


    }

    public abstract class Componente
    {
        public abstract void Crear(ComponenteBE componente);
        //void Unir(ComponenteBE componente, GrupoBE grupo);
        public abstract void Eliminar(ComponenteBE componente);
        public abstract void Modificar(ComponenteBE componente);
    }







}
