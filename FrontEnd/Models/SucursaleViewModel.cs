using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class SucursaleViewModel
    {

        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Compañia")]
        [Required]
        public int compania { get; set; }
        public Compania comp { get; set; }
        public IEnumerable<Compania> companias { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string dirrecion { get; set; }

    }
}