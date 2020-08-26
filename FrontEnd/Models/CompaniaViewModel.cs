using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class CompaniaViewModel
    {
        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Identificador actividad económica")]
        [Required]
        public int actividad_economica { get; set; }
        public IEnumerable<Actividades_Economica> actividades_economicas { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Cédula Jurídica")]
        [Required]
        public string cedula_juridica { get; set; }
        [Display(Name = "Identificador tipo de compañía")]
        [Required]
        public int tipo_compania { get; set; }
        public IEnumerable<Tipo_Compania> tipo_companias { get; set; }
        [Display(Name = "Teléfono")]
        [Required]
        public string telefono { get; set; }
        [Display(Name = "Nombre del contacto")]
        [Required]
        public string nombre_contacto { get; set; }
        [Display(Name = "Primer apellido del contacto")]
        [Required]
        public string apellido1_contacto { get; set; }
        [Display(Name = "Segundo apellido del contacto")]
        [Required]
        public string apellido2_contacto { get; set; }
        [Display(Name = "E-mail del contacto")]
        [Required]
        public string email_contacto { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string direccion { get; set; }

    }
}