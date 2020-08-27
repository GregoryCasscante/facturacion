using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class CategoriaProductoViewModel
    {
        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string nombre { get; set; }
        [Display(Name = "Detalle")]
        [Required(ErrorMessage = "Debe ingresar un detalle")]
        public string detalle { get; set; }
        [Display(Name = "Minimo")]
        [Required(ErrorMessage = "Debe ingresar un minimo")]
        public int minimo { get; set; }
        [Display(Name = "Venta Minima")]
        [Required(ErrorMessage = "Debe ingresar un valor de venta minima")]
        public int ventaMinimo { get; set; }
        [Display(Name = "Exento")]
        [Required(ErrorMessage = "Debe ingresar un valor")]
        public int execento { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Debe ingresar un precio")]
        public decimal precio { get; set; }

    }
}