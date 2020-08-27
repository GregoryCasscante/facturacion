using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class InventarioViewModel
    {
        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        public int categoria { get; set; }
        [Display(Name = "Categoria")]
        public string nombre_categoria { get; set; }
        public IEnumerable<Categorias_Productos> categorias { get; set; }
        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe seleccionar un proveedor")]
        public int proveedor { get; set; }
        [Display(Name = "Proveedor")]
        public string nombre_proveedor { get; set; }
        public IEnumerable<Proveedor> proveedores { get; set; }
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe ingresar una cantidad")]
        public int cantidad { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Debe seleccionar una descripcion")]
        public string descripcion { get; set; }
        [Display(Name = "Minimo")]
        [Required(ErrorMessage = "Debe ingresar un minimo")]
        public int minimo { get; set; }
        [Display(Name = "Venta Minima")]
        [Required(ErrorMessage = "Debe ingresar una valor de venta minima")]
        public int ventaMinima { get; set; }
        [Display(Name = "Exento")]
        [Required(ErrorMessage = "Debe ingresar un valor")]
        public int exento { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Debe ingresar un precio")]
        public int precio { get; set; }

    }
}