using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class MantenimientoViewModel
    {
        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        public string descripcion { get; set; }

    }
}