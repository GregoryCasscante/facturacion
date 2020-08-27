using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class TipoCambioViewModel
    {
        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Valor de Compra")]
        [Required(ErrorMessage = "Debe ingresar una valor de compra")]
        public decimal compra { get; set; }
        [Display(Name = "Valor de Venta")]
        [Required(ErrorMessage = "Debe ingresar un valor de venta")]
        public decimal venta { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }

    }
}