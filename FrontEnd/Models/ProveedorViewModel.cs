using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProveedorViewModel
    {

        [Display(Name = "Identificador")]
        [Required]
        [Key]
        public int id { get; set; }
        [Display(Name = "Identificador de la Compañia")]
        [Required]
        public int id_compania { get; set; }
        public IEnumerable<Compania> companias { get; set; }
        [Display(Name = "Nombre Comercial")]
        [Required]
        public string nombre_comercial { get; set; }
        [Display(Name = "DNI")]
        [Required]
        public string dni { get; set; }
        [Display(Name = "Tipo de DNI")]
        [Required]
        public int tipo_dni { get; set; }
        [Display(Name = "Actividad Económica")]
        [Required]
        public int actividad_economica { get; set; }
        public IEnumerable<Actividades_Economicas> actividades_economicas { get; set; }
        [Display(Name = "E-mail primario")]
        [Required]
        public string email1 { get; set; }
        [Display(Name = "E-mail secundario")]

        public string email2 { get; set; }
        [Display(Name = "Teléfono primario")]
        [Required]
        public string telefono1 { get; set; }
        [Display(Name = "Teléfono secundario")]

        public string telefono2 { get; set; }
        [Display(Name = "País")]
        [Required]
        public int pais { get; set; }
        public IEnumerable<Pais> paises { get; set; }
        [Display(Name = "Provincia")]
        [Required]
        public int provincia { get; set; }
        public IEnumerable<Provincia> provincias { get; set; }
        [Display(Name = "Cantón")]
        [Required]
        public int canton { get; set; }
        public IEnumerable<Canton> cantones { get; set; }
        [Display(Name = "Distito")]
        [Required]
        public int distrito { get; set; }
        public IEnumerable<Distrito> distritos { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        public string direccion { get; set; }

    }
}