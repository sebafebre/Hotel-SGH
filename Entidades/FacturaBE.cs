﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Table("Factura")]
    public partial class FacturaBE
    {
        #region Atributos privados
        private int id;
        private string emisor;
        private string tipoFactura;
        private int nroFactura;
        private DateTime fechaEmision;
        private string estado;
        private EmpleadoBE empleado;
        private PedidoBE pedido;
        #endregion



        #region Propiedades publicas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Emisor { get; set; }
        public string TipoFactura { get; set; }
        public int NroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Estado { get; set; }

        

        public virtual EmpleadoBE Empleado { get; set; }
        public virtual PedidoBE Pedido { get; set; }
        #endregion


    }
}
